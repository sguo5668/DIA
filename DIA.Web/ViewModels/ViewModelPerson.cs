using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DIA.Web.ViewModels
{
    public class ViewModelPerson
    {
        public int UserType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UniqueNumber { get; set; }
        public string SSN { get; set; }
        public DateTime DOB { get; set; }
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
    }
}
