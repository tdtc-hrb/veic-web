using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using veic_web.Models.Repositories;

namespace veic_web.Models.Services
{
    public class EFQualificationRepository : IQualificationRepository
    {
        private readonly CarnumberDbContext context;
        public EFQualificationRepository(CarnumberDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Qualification> Qualifications => context.Qualifications;
    }
}
