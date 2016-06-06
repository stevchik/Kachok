namespace Kachok.Infrastructure.Logging
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
