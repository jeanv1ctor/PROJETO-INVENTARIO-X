using Microsoft.EntityFrameworkCore;
using Api_Inventario.Models;

namespace Api_Inventario.Data
{
    public class AppDbContext : DbContext
    {

        public DbSet<ItemModel> Items { get; set; }
        public DbSet<UserModel> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("DataSource=app.db;Cache=Shared");

    }
}
