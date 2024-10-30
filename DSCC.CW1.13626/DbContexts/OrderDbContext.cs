using DSCC.CW1._13626.Model;
using Microsoft.EntityFrameworkCore;

namespace DSCC.CW1._13626.DbContexts
{
    public class OrderDbContext:DbContext
    {
       
            public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options) { }


            public DbSet<Customer> Customers { get; set; }
            public DbSet<Order> Orders { get; set; }
        
    }
}
