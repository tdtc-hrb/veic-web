using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using veic_web.Models.Repositories;

namespace veic_web.Models.Services
{
    public class EFImageRepository : IImageRepository
    {
        private readonly CarnumberDbContext context;
        public EFImageRepository(CarnumberDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Image> Images => context.Images;
    }
}
