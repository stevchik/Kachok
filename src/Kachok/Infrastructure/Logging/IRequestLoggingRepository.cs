namespace Kachok.Infrastructure.Logging
{
    public interface IRequestLoggingRepository
    {
        void AddLog(RequestLog log);
        bool SaveAll();
    }
}