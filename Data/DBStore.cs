using Microsoft.EntityFrameworkCore;
using WEBTEST.Models;

namespace WEBTEST.Data
{
    public class DBStore: DbContext
    {
        public DBStore(DbContextOptions<DBStore> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
