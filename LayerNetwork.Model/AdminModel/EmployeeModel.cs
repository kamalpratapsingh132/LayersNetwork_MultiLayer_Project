using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LayerNetwork.Model.AdminModel
{
    public class EmployeeModel
    {     
        public int ID { get; set; }

        [Required(ErrorMessage = "*")]
        public string Name { get; set; }


        [Required(ErrorMessage = "*")]
        public int Age { get; set; }


        [Required(ErrorMessage = "*")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }


        [Required(ErrorMessage = "*")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required(ErrorMessage = "*")]
        public string Gender { get; set; }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                    ErrorMessage = "ENTERED NUMBER FORMET IS NOT VALID.")]
        public string PhoneNumber { get; set; }


        [Required(ErrorMessage = "*")]
        public string Address { get; set; }
    }
}
