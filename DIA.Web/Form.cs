using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DIA.Web
{
    public class Form
    {
        [Key]
        public int Id { get; set; }
        public int FormTypeCode { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public Claim Claim { get; set; }
    }
}
