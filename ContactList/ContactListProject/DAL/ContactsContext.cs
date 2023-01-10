using Microsoft.EntityFrameworkCore;
using ContactListProject.model;

namespace ContactListProject.DAL
{
    public class ContactsContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ContactList;Trusted_Connection=True;");
        }
    }
}
