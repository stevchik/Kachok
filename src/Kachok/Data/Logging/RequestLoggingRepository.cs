using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kachok.Data.Logging
{
    public class RequestLoggingRepository : IRequestLoggingRepository
    {
        private KachokLoggingContext _context;

        public RequestLoggingRepository(KachokLoggingContext context)
        {
            this._context = context;
        }

        public void AddLog(RequestLog log)
        {
            _context.Logs.Add(log);
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }


    }
}
