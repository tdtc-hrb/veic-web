using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace veic_web.Models
{
    public class EFParameterRepository : IParameterRepository
    {
        private readonly CarnumberDbContext context;

        public EFParameterRepository(CarnumberDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Parameter> Parameters => context.Parameters;
    }
}
