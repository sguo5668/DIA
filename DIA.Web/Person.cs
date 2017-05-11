using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DIA.Web
{
    public class Person
    {

        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

		public string FullName {
			get
			{
				return FirstName + " " + LastName;
			}
		}
		public string SSN { get; set; }

		public string ECN { get; set; }

		public string UniqueNumber { get; set; }


		[DataType(DataType.Date)]

		public DateTime DOB { get; set; }
        public int PreferredLanguageCode { get; set; }

		[EmailAddress(ErrorMessage = ResourceKeys.NotAValidEmail)]
		[Display(Name = ResourceKeys.YourEmail)] 
        public string Email { get; set; }
		public int? PreferredCommunicationChannelCode { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    }
}
