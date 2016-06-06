using Microsoft.EntityFrameworkCore;
using System;

namespace Kachok.Infrastructure
{
    public interface IDbFactory<DContext> : IDisposable
        where DContext : DbContext
    {
        DContext Init();
    }
}
