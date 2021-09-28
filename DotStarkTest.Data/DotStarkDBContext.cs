using DotStarkTest.Data.EntityModel;
using Microsoft.EntityFrameworkCore;
using System;

namespace DotStarkTest.Data
{
    public class DotStarkDBContext : DbContext
    {
        public DotStarkDBContext(DbContextOptions<DotStarkDBContext> options) : base(options)
        {
        }
        public DbSet<Products> Products { get; set; }
    }
}
