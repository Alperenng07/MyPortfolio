using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Education : BaseEntity


    {
      
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Departmant is required.")]
        public string Departmant { get; set; }
        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; }
        [Required(ErrorMessage = "Country is required.")]
        public string Country { get; set; }
        [Required(ErrorMessage = "GraduateDate is required.")]
        public string GraduateDate { get; set; }
    }
}
