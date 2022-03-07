using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Layers.DAL.EntityDbContext
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Please enter name")]
        [StringLength(100)]
        public string Name { get; set; }

        
        public int Age { get; set; }

        [Required(ErrorMessage = "Please enter email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Please enter password")]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$ %^&*-]).{8,}$",
            ErrorMessage = "ENTERED NUMBER FORMET IS NOT VALID.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please choose gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Please enter phone number")]
        [RegularExpression(@"^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$",
                    ErrorMessage = "ENTERED NUMBER FORMET IS NOT VALID.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please enter Address")]
        public string Address { get; set; }
    }
}
