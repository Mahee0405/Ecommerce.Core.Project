using System;
using Microsoft.EntityFrameworkCore;
using skinet.Core.Entities;

namespace skinet.API.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }

        public DbSet<Products> Products { get; set; }

    }
}
