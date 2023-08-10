using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class User:BaseEntity
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "SurName is required.")]
        public string SurName{ get; set; }

    
        [Required(ErrorMessage = "Email is required.")]
        public string Email{ get; set; }
        [Required(ErrorMessage = "Phone is required.")]
        public string Phone{ get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string Password{ get; set; }
       
       public Guid RoleId { get; set; }
        public Role Role { get; set; }
       



        public virtual ICollection<Comment>? Comments { get; set; }
        public virtual ICollection<Offer>? Offers { get; set; }


    }
}
