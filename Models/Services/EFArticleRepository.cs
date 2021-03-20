using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace veic_web.Models
{
    public class EFArticleRepository : IArticleRepository
    {
        private readonly CarnumberDbContext _context;
        public EFArticleRepository(CarnumberDbContext ctx)
        {
            _context = ctx;
        }
        public IQueryable<Article> Articles => _context.Articles;
    }
}
