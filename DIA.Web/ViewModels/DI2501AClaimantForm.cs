using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIA.Web.ViewModels
{
    public class DI2501AClaimantForm
    {
        public int ClaimType { get; set; }
        public int PersonID { get; set; }
        public Form Form { get; set; }
        public FormOtherName FormOtherName { get; set; }
        public DI2501AForm DI2501AForm { get; set; }
        public Person Person { get; set; }
        public PersonPhoneNumber PersonPhoneNumber { get; set; }
        public PersonAddress PersonAddress { get; set; }
    }
}