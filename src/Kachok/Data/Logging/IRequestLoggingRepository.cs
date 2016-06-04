using System;

namespace Kachok.Data.Logging
{
    public interface IRequestLoggingRepository
    {
        void AddLog(RequestLog log);
        bool SaveAll();
    }
}