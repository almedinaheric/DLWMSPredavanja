using DLWMS.Core;
using Microsoft.EntityFrameworkCore;

namespace DLWMS.Repository
{
    public class DLWMSDbContext : DbContext
    {
        public DLWMSDbContext(DbContextOptions<DLWMSDbContext> contextOptions) : base(contextOptions)
        {

        }

        public DbSet<Student> Studenti { get; set; }
        public DbSet<Predmet> Predmeti { get; set; }
    }
}