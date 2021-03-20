using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace veic_web.Models
{
    public interface INavigationRepository
    {
        IQueryable<Navigation> Navigations { get; }
    }
}
