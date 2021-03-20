using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace veic_web.Models.Repositories
{
    public interface IQualificationRepository
    {
        IQueryable<Qualification> Qualifications { get; }
    }
}
