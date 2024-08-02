using Microsoft.EntityFrameworkCore;
using ToDoList.Models;
namespace ToDoList.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> users {  get; set; }
        public DbSet<TheList> list { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var builder = new ConfigurationBuilder().
            AddJsonFile("appsettings.json",true,reloadOnChange:true).Build();
            var connection = builder.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connection);
              
        }
    }
}
