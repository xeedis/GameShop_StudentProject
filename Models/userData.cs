using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GameShop.Models
{
    public class userData
    {
        public string Name { get; set; }
       
        public string Surname { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        [RegularExpression(@"(\+\d{2})*[\d\s-]+", ErrorMessage = "Błędny format numeru telefonu.")]
        public string Phone { get; set; }

        [EmailAddress(ErrorMessage = "Błędny format adres e-mail.")]
        public string Email { get; set; }

    }
}