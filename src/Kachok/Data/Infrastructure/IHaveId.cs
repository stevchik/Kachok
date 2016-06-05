using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kachok.Data.Infrastructure
{
    public interface IHaveId
    {
        int Id { get; }
    }
}
