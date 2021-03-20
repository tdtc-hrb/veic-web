using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace veic_web.Models
{
    public class EFNavigationRepository : INavigationRepository
    {
        private readonly CarnumberDbContext context;

        public EFNavigationRepository(CarnumberDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Navigation> Navigations => context.Navigations;
    }
}
