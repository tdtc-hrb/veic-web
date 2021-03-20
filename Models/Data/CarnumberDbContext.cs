using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;

namespace veic_web.Models
{
    public class CarnumberDbContext : DbContext
    {
        public CarnumberDbContext(DbContextOptions<CarnumberDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products
        {
            get; set;
        }

        public DbSet<Navigation> Navigations
        {
            get; set;
        }

        public DbSet<Parameter> Parameters { get; set; }

        public DbSet<Article> Articles { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<Qualification> Qualifications { get; set; }
    }
}
