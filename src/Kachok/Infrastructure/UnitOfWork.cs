using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kachok.Infrastructure
{
    public class UnitOfWork<DContext> : IUnitOfWork
        where DContext : DbContext
    {
        private readonly IDbFactory<DContext> dbFactory;
        private DContext dbContext;

        public UnitOfWork(IDbFactory<DContext> dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public DContext DbContext
        {
            get { return dbContext ?? (dbContext = dbFactory.Init()); }
        }

        public void Commit()
        {
            DbContext.SaveChanges();
        }
    }

}
