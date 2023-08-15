using System.ComponentModel.DataAnnotations;

namespace MyPortfolio.UI.Models
{
    public class CommentView
    {
        [Required(ErrorMessage = "Description is required.")]

        public string Text { get; set; }
        public string? Answer { get; set; }
        public Guid? UserId { get; set; }
    }
}
 