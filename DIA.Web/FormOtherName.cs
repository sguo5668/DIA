using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DIA.Web
{
    public class FormOtherName
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string SSN { get; set; }
        public string Phone { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        [Required]
        public Form Form { get; set; }
    }
}
