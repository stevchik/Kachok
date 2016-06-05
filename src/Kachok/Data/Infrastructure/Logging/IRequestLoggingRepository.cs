namespace Kachok.Data.Infrastructure.Logging
{
    public interface IRequestLoggingRepository
    {
        void AddLog(RequestLog log);
        bool SaveAll();
    }
}