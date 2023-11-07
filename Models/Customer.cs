using CheckoutSystem.Enums;
using System.ComponentModel.DataAnnotations;

namespace CheckoutSystem.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }
        public CustomCustomerType CustomerType { get; set; }
        public ICollection<Film>? Films { get; set; }
    }
}
