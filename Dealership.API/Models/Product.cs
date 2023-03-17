using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Dealership.API.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Brand { get; set; } = string.Empty;
        [Required]
        public string CarModel { get; set; } = string.Empty;
        [Required]
        public int AcquisitionDate { get; set; }
        public bool IsAvailable { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [JsonIgnore]
        public virtual Category? Category { get; set; }

    }
}
