namespace App.Core.Models
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public String CreateDate { get; set; }
    }
}
