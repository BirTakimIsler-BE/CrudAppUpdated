using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAppUpdated.WebUI.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        public string Email { get; set; }

        [DisplayName("Last Edit Time")]
        public DateTime LastEditTime { get; set; }
    }
}
