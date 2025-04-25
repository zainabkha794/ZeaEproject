using changes_project.Models;
using Eproject.Areas.Identity.Data;
using Eproject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eproject.Data
{
    public class EprojectContext : IdentityDbContext<EprojectUser>
    {
        public EprojectContext(DbContextOptions<EprojectContext> options)
            : base(options)
        {
        }

        // DbSets for your entities
        public DbSet<Course> Course { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Batch> Batches { get; set; }
        public DbSet<Student> Students { get; set; }
        public object Courses { get; internal set; }




        // Overriding OnModelCreating to configure relationships
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // One-to-One: Faculty ↔ EprojectUser (Relationship between Faculty and User)

            // One-to-One: Student ↔ EprojectUser (Relationship between Student and User)


            // One-to-Many: Batch → Students (A Batch can have many students)

            // Applying custom configurations for EprojectUser if needed
            builder.ApplyConfiguration(new EprojectUserEntityConfiguration());
        }


        // Custom configuration class for EprojectUser
        internal class EprojectUserEntityConfiguration : IEntityTypeConfiguration<EprojectUser>
        {
            public void Configure(EntityTypeBuilder<EprojectUser> builder)
            {
                // Ensure first and last names have a maximum length of 255 characters
                builder.Property(x => x.FirstName).HasMaxLength(255);
                builder.Property(x => x.LastName).HasMaxLength(255);

                // Default value for Role column
                builder.Property(x => x.Role)
                    .HasMaxLength(255)
                    .HasDefaultValue('0');
            }
        }
    }
}