using System.Data.Entity;

using TargetShooting.Models;

namespace TargetShooting.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<Winner> Winners
        {
            get;
            set;
        }

        public virtual DbSet<Probability> Probabilities
        {
            get;
            set;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}