using CRUDlabSODRE.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDlabSODRE.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<SodreModel> Sodre { get; set; }    
    }
}
