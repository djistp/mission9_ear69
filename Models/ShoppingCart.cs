using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mission9_ear69.Models
{
    public class ShoppingCart
    {   [Key]
        [BindNever]
        public int ShoppingCartId { get; set; }

        [BindNever]
        public ICollection<BasketLineItem> Lines { get; set; }
        [Required(ErrorMessage ="Enter name:")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter address:")]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }

        [Required(ErrorMessage = "Enter city:")]
        public string City { get; set; }
        [Required(ErrorMessage = "Enter State:")]
        public string State { get; set; }
        public string Zip { get; set; }
        [Required(ErrorMessage = "Enter country:")]
        public string Country { get; set; }

    }
}
