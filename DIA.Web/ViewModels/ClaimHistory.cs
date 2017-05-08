using System;
using System.Collections.Generic;
using System.Text;

namespace DIA.Web
{
    public class ClaimHistory
    {

        public string Id { get; set; }

        public string ClaimIDNumber { get; set; }

        public string ClaimType { get; set; }

        public int ClaimantID { get; set; }

        public DateTime EffectiveDate { get; set; }

    }
}