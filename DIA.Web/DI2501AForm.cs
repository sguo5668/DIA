using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DIA.Web
{
    public class DI2501AForm
    {
        [Key]
        public int Id { get; set; }

        public Boolean IsSelffEmployed { get; set; }
        public Boolean IsStateEmloyee  { get; set; }
        public Boolean UnderLawEnforcement { get; set; }
        public DateTime LastDayWorked { get; set; }
        public DateTime DisabilityBeginDate { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        [Required]
        public Form Form { get; set; }

    }
}
