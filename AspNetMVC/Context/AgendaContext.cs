using AspNetMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetMVC.Context
{
    public class AgendaContext :DbContext
    {
        public AgendaContext(DbContextOptions<AgendaContext> options) : base(options) { 
        }
        public DbSet<Contact> Contacts { get; set; }
    }
}
