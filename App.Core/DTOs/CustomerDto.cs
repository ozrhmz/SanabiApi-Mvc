using App.Core.Models;

namespace App.Core.DTOs
{
    public class CustomerDto : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public string NumberPhone { get; set; }
        public string BirtDate { get; set; }

    }
}
