namespace App.Core.Models
{
    public class PaymentType : BaseEntity
    {
        public string TypeName { get; set; }

        public ICollection<Order> orders { get; set; }
    }
}
