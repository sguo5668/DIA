using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIA.Web
{
    public class Claimant
    {

        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SSN { get; set; }
        public DateTime DOB { get; set; }
        public int Language { get; set; }
        public int PreferredCommunication { get; set; }

        public Person Person { get; set; }
    }
}
