using Microsoft.EntityFrameworkCore;
using System;

namespace Kachok.Data.Infrastructure
{
    public interface IDbFactory<DContext> : IDisposable
        where DContext : DbContext
    {
        DContext Init();
    }
}
