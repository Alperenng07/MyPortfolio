using Entities;

namespace MyPortfolio.UI.Models
{
    public class ModeratorFullViewModel
    {
        public IEnumerable<Moderator> Moderators { get; set; }
        public IEnumerable<Job> Jobs { get; set; }
        public IEnumerable<Language> Languages { get; set; }
        public IEnumerable<Skill> Skills { get; set; }
        public IEnumerable<Education> Educations { get; set; }
        public IEnumerable<Project> Projects { get; set; }
        public IEnumerable<Experience> Experiences { get; set; }
       



    }
}
