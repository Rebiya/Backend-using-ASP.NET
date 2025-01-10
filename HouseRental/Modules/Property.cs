using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HouseRental.Modules
{
    public class Property
    {
        [Key]
        public int PropertyId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(15,2)")]
        public decimal Price { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Subcity { get; set; }
        public string PropertyType { get; set; }
        public int Bedrooms { get; set; }
        public int Bathroom { get; set; }
        public string Imgurl { get; set; }
        public string Status { get; set; }
        public string Category { get; set; }
        [ForeignKey("Staff")]
        public int StaffId { get; set; }
    }
}