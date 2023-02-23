using CleanArchitecture.Domain.Entities.Shop.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Context
{
    public class AppDbContext : DbContext//, IAppDbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}
