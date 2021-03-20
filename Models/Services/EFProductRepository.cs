using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace veic_web.Models
{
    public class EFProductRepository : IProductRepository
    {
        private readonly CarnumberDbContext context;

        public EFProductRepository(CarnumberDbContext ctx)
        {
            this.context = ctx;
        }

        public IQueryable<Product> Products => context.Products;
    }
}
