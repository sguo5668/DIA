using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIA.Web.ViewModels
{
    public class DI2501AClaimantForm
    {
        public int ClaimType { get; set; }
        public Form Form { get; set; }
        public FormOtherName FormOtherName { get; set; }
        public DI2501AForm DI2501AForm { get; set; }
    }
}