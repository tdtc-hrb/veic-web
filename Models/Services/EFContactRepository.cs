using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using veic_web.Models.Repositories;

namespace veic_web.Models.Services
{
    public class EFContactRepository : IContactRepository
    {
        private readonly CarnumberDbContext context;
        public EFContactRepository(CarnumberDbContext ctx)
        {
            this.context = ctx;
        }
        public IQueryable<Contact> Contacts => context.Contacts;
    }
}
