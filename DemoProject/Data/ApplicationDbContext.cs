using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DemoProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        #region Constructor

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        #endregion Constructor

        #region DatabaseSets

        public DbSet<DemoProject.Models.Person> Person { get; set; }
        public DbSet<DemoProject.Models.Address> Address { get; set; }
        public DbSet<DemoProject.Models.EmailContact> EmailContact { get; set; }
        public DbSet<DemoProject.Models.TelephoneContact> TelephoneContact { get; set; }

        #endregion DatabaseSets
    }
}
