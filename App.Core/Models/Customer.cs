namespace App.Core.Models
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public string NumberPhone { get; set; }
        public string BirtDate { get; set; }

        //İlişkiler
        public ICollection<Adress> adresses { get; set; }
        public ICollection<Order> orders { get; set; }
    }
}
