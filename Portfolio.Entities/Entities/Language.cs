using Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Language : BaseEntity
    {
   

        [Required(ErrorMessage = "Name is required.")]
        public string name { get; set; }
        [Required(ErrorMessage = "Level is required.")]
        public int Level { get; set; }
        [Required(ErrorMessage = "Score is required.")]
        public Score Score { get; set; }
    }
}
