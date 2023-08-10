

using Microsoft.AspNetCore.Identity;

namespace Entities
{
    public class Role:BaseEntity
    {
        public virtual ICollection<User>? Users { get; set; }
    }
}
