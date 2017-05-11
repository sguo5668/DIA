using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIA.Web
{
    public class PersonAddress
    {

		public int Id { get; set; }

		public int PersonID { get; set; }

		public int AddressTypeCode { get; set; }
		public string AddressLine1 { get; set; }
		public string AddressLine2 { get; set; }

		public int StateCode { get; set; }
		public string City { get; set; }
		public string ZipCode { get; set; }
		public string ZipCodeExt { get; set; }
		public string CountryCode { get; set; }
		public bool IsAddressInternational { get; set; }

		public string InternationalStateCode { get; set; }
		public string InternationalPostalCode { get; set; }

		public string OtherCountry { get; set; }
		public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
	}
}
