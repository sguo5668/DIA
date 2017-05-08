using System;
using System.Collections.Generic;
using System.Text;

namespace DIA.Web
{
    public class Claim
    {

        public int Id { get; set; }

        public string ClaimIDNumber { get; set; }

        public int ClaimTypeCode { get; set; }

        public int ClaimantID { get; set; }

        public DateTime EffectiveDate { get; set; }

    }
}
