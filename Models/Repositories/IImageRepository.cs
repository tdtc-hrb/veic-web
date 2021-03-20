using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace veic_web.Models.Repositories
{
    public interface IImageRepository
    {
        IQueryable<Image> Images { get; }
    }
}
