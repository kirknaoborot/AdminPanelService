using AdminPanelService.Data.Domain;
using Microsoft.EntityFrameworkCore;

namespace AdminPanelService.Data.Context
{
    public class AdminPanelContext : DbContext
    {
        public DbSet<Reception> Receptions { get; set; }

        public AdminPanelContext(DbContextOptions<AdminPanelContext> options): base(options)
        {
            Database.EnsureCreated();
        }
    }
}
