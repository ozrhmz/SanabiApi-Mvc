using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Core.Models
{
    public class OrderProduct
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int id { get; set; }

        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int ProductQuantity { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
