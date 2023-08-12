using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Comment:BaseEntity
    {
        [Required(ErrorMessage = "Description is required.")]
       
        public string Text { get; set; }
        public string? Answer { get; set; }
        public Guid? UserId { get; set; }
    }
}
