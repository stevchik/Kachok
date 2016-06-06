using Kachok.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kachok.Infrastructure
{
    public class DbFactory<DContext> : Disposable, IDbFactory<DContext>
        where DContext : DbContext
    {
        DContext dbContext;


        public DContext Init()
        {
            return dbContext ?? (dbContext = Activator.CreateInstance<DContext>());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }

       
    }

}
