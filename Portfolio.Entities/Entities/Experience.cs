using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Experience : BaseEntity
    {
       

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Description is required.")]
        [StringLength(20, ErrorMessage = "Description must be less than 20 characters.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Year is required.")]
        public int Year { get; set; }
    }
}
