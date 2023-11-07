using CheckoutSystem.Enums;
using System.ComponentModel.DataAnnotations;

namespace CheckoutSystem.Models
{
    public class Film
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Titel { get; set; }

        public CustomMediaType FilmMediaType { get; set; }

        public int Price { get; set; }

        //Foreig key
        public int? CustomerId { get; set; }

        //Navigation property
        public Customer? Customer { get; set; }
    }
}
