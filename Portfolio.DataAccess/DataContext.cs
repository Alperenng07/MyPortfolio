using Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

public class DataContext : DbContext
{
    private IConfiguration _configuration { get; set; }
   



    public DataContext(DbContextOptions<DataContext> options, IConfiguration configuration) : base(options) {
        _configuration = configuration;
    }

    //public DataContext()
    //{
    //}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));
    }

    public DbSet<Job> Jobs { get; set; }
    public DbSet<Education> Educations { get; set; }
    public DbSet<Experience> Experiences { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Language> Languages { get; set; }
    public DbSet<Moderator> Moderators { get; set; }
    public DbSet<Offer> Offers { get; set; }
    public DbSet<Project> Projects { get; set; }
    
    public DbSet<Skill> Skills { get; set; }
    public DbSet<User> Users { get; set; }
   

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        ProcessSaveChanges();
        return base.SaveChangesAsync(cancellationToken);

    }

    private void ProcessSaveChanges()
    {
        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                    break;
                case EntityState.Modified:
                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                    break;
            }
        }
    }

   
}
