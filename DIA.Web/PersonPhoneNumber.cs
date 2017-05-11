using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIA.Web
{
    public class PersonPhoneNumber
    {
		public int Id { get; set; }
		public int PersonID { get; set; }
		public string PhoneNumber { get; set; }
		public string PhoneNumberExt { get; set; }
		public int PhoneNumberTypeCode { get; set; }
		public bool IsPrimary { get; set; }

		public bool IsInternatioal { get; set; }

		public int CountryCode { get; set; }
		public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
	}
}
