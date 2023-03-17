namespace Dealership.API.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}
