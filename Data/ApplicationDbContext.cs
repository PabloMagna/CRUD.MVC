using Microsoft.EntityFrameworkCore;
using MVC_FirstPracticeCRUD.Models;

namespace MVC_FirstPracticeCRUD.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<Contact> Contacts { get; set; }
    }
}
