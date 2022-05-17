using System.ComponentModel.DataAnnotations;

namespace Orders.Tests.IntegrationTests.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        public string Status { get; set; }
    }
}