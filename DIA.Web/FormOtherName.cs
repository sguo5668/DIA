using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DIA.Web
{
    public class FormOtherName
    {
        [Key]
        public int Id { get; set; }
     
		[Required(ErrorMessage = ResourceKeys.Required)]
		[Display(Name = ResourceKeys.FirstName)]
		public string FirstName { get; set; }

		[Required(ErrorMessage = ResourceKeys.Required)]
		[Display(Name = ResourceKeys.LastName)]
		public string LastName { get; set; }
		[Display(Name = ResourceKeys.SSN)]
		public string SSN { get; set; }

		[Display(Name = ResourceKeys.MiddleName)]
		public string MiddleName { get; set; }

		[Display(Name = ResourceKeys.Suffix)]
		public string Suffix { get; set; }

		public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        [Required]
        public Form Form { get; set; }
    }
}
