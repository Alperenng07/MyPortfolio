using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Moderator:BaseEntity
    {
       

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Phone is required.")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Mail is required.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Adress is required.")]
        public string Adress { get; set; }
        [Required(ErrorMessage = "Github is required.")]
        public string Github { get; set; }
        [Required(ErrorMessage = "Linedln is required.")]
        public string Linedln { get; set; }
        [Required(ErrorMessage = "Instagram is required.")]
        public string Instagram { get; set; }
        [Required(ErrorMessage = "Twitter is required.")]
        public string Twitter { get; set; }


    }
}
