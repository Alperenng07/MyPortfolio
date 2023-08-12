using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Offer : BaseEntity
    {
       

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(20, ErrorMessage = "Description must be less than 20 characters.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Content is required.")]
        public string Content { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(0.1, double.MaxValue)]
        public int Price { get; set; }

        [Required(ErrorMessage = "Delivery time is required.")]
        public string DeliveryTime { get; set; }


        
        public Guid? UserId { get; set; }
    }
}
