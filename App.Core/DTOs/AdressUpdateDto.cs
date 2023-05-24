namespace App.Core.DTOs
{
    public class AdressUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Province { get; set; }
        public string Districte { get; set; }
        public string Neighbourhood { get; set; }
        public string Street { get; set; }
        public int Building_No { get; set; }
        public int Post_Code { get; set; }
        public int Apartment_Number { get; set; }
        public string adressDetails { get; set; }
        public string numberPhone { get; set; }
        public int CustomerId { get; set; }
        public string CreateDate { get; set; }
    }
}
