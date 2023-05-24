using App.Api.Filters;
using App.Core.DTOs;
using App.Core.Models;
using App.Core.Services;
using App.Repository;
using App.Service.Services;
using Autofac.Core;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Linq;

namespace App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IOrderService _orderService;
        private readonly IProductService _prdService;
        private readonly IService<OrderProduct> _productService;
        private readonly AppDbContext _appDbContext;

        public OrderController(IMapper mapper, IService<OrderProduct> productService, IOrderService orderService, AppDbContext appDbContext, IProductService prdService)
        {
            _mapper = mapper;
            _productService = productService;
            _orderService = orderService;
            _appDbContext = appDbContext;
            _prdService = prdService;
        }

        [HttpGet]
        public IActionResult GetOrdersWithProducts()
        {
            var ordersWithProducts = _appDbContext.Orders
                .Include(o => o.products)
                .ThenInclude(op => op.Product)
                .Include(o => o.PaymentType)
                .Include(o => o.orderStatus)
                .Include(o => o.customer)
                .ToList();
            var orderDtos=_mapper.Map<List<OrderDto>>(ordersWithProducts);
            return Ok(orderDtos);
        }

        [ServiceFilter(typeof(NotFoundFilter<Order>))]
        [HttpGet("[action]")]
        public IActionResult GetOrdersById(int selectId)
        {
            var ordersWithProducts = _appDbContext.Orders
                .Include(o => o.products)
                .ThenInclude(op => op.Product)
                .Include(o => o.PaymentType)
                .Include(o => o.orderStatus)
                .Include(o => o.customer)
                .Where(o => o.Id==selectId)
                .ToList();
            var ordersWithProductsDto = ordersWithProducts.Select(o => new OrderDto
            {
                Id = o.Id,
                CustomerId = o.CustomerId,
                customer = new CustomerDto
                {
                    Id = o.CustomerId,
                    Name = o.customer.Name,
                    Surname = o.customer.Surname,
                    NumberPhone = o.customer.NumberPhone
                },
                AdressId = o.AdressId,
                PaymentTypeId = o.PaymentTypeId,
                paymentType = new PaymentTypeDto
                {
                    Id = o.PaymentTypeId,
                    TypeName = o.PaymentType.TypeName
                },
                OrderStatusId = o.OrderStatusId,
                orderStatus = new OrderStatusDto
                {
                    Id = o.OrderStatusId,
                    StatusType = o.orderStatus.StatusType
                },
                CreateDate = o.CreateDate,
                _Products = o.products.Select(op => new OrderProductDto
                {
                    OrderId = op.OrderId,
                    ProductId = op.ProductId,
                    ProductQuantity=op.ProductQuantity,
                    product = new ProductDto
                    {
                        Id = op.ProductId,
                        Name = op.Product.Name,
                        Price = op.Product.Price,
                        Description = op.Product.Description,
                        Image = op.Product.Image,
                        CategoryId=op.Product.CategoryId
                    }
                }).ToList(),
                amount = o.amount
            }).ToList();
            return Ok(ordersWithProductsDto);
        }

        [ServiceFilter(typeof(NotFoundFilter<Customer>))]
        [HttpGet("{id}")]
        public IActionResult GetOrdersWithProductsByCustomerId(int id) 
        {
            var ordersWithProducts=_appDbContext.Orders
                .Include(o=> o.products)
                .ThenInclude(op=> op.Product)
                .Include(o=>o.PaymentType)
                .Include(o=>o.orderStatus)
                .Include(o=>o.customer)
                .Where(o=> o.CustomerId == id)
                .ToList();
            var ordersWithProductsDto=ordersWithProducts.Select(o=>new OrderDto
            {
                Id= o.Id,
                CustomerId=o.CustomerId,
                customer=new CustomerDto
                {
                    Id = o.CustomerId,
                    Name=o.customer.Name,
                    Surname=o.customer.Surname,
                    NumberPhone=o.customer.NumberPhone
                },
                AdressId=o.AdressId,
                PaymentTypeId=o.PaymentTypeId,
                paymentType=new PaymentTypeDto
                {
                    Id = o.PaymentTypeId,
                    TypeName=o.PaymentType.TypeName
                },
                OrderStatusId =o.OrderStatusId,
                orderStatus=new OrderStatusDto
                {
                    Id = o.OrderStatusId,
                    StatusType=o.orderStatus.StatusType
                },
                CreateDate=o.CreateDate,
                _Products=o.products.Select(op=>new OrderProductDto
                {
                    OrderId=op.OrderId,
                    ProductId=op.ProductId,
                    ProductQuantity=op.ProductQuantity,
                    product=new ProductDto
                    {
                        Id = op.ProductId,
                        Name=op.Product.Name,
                        Price=op.Product.Price,
                        Description=op.Product.Description,
                        Image=op.Product.Image,
                        CategoryId=op.Product.CategoryId
                        
                    }
                }).ToList(),
                amount=o.amount,
            }).ToList();
            return Ok(ordersWithProductsDto);
        }



        [HttpPost]
        public async Task<IActionResult> Save(OrderDto orderDto)
        {
            var order = await _orderService.AddAsync(_mapper.Map<Order>(orderDto));
            var _orderDto = _mapper.Map<OrderDto>(order);
            _orderDto._Products = new List<OrderProductDto>().Cast<OrderProductDto>().ToList();

            foreach (OrderProductDto productDto in orderDto._Products)
            {
                var orderProduct = new OrderProduct { OrderId = order.Id, ProductId = productDto.ProductId, ProductQuantity=productDto.ProductQuantity};
                var resOrderProduct = await _productService.AddAsync(orderProduct);
                await _prdService.UpdateStockAsync(productDto.ProductId, productDto.ProductQuantity); //Stock Düşürmek İçin
                _orderDto._Products.Add(new OrderProductDto()
                {
                    OrderId = resOrderProduct.OrderId,
                    ProductId = productDto.ProductId,
                    ProductQuantity= resOrderProduct.ProductQuantity
                });
            }
            return CreateActionResult(CustomResponseDto<OrderDto>.Succes(201, _orderDto));
        }

        [HttpPut]
        public async Task<IActionResult> orderStatusUpdate(int orderId , int statusId)
        {
           await _orderService.OrderStatusUpdateAsync(orderId, statusId);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Succes(204));
        }

        [ServiceFilter(typeof(NotFoundFilter<Order>))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var order = await _orderService.GetByIdAsync(id);
            await _orderService.RemoveAsync(order);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Succes(204));
        }

    }
}
