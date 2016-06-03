using System;

namespace Kachok.Data.Logging
{
    public interface ILoggingRepository: IDisposable
    {
        void AddLog();
        bool SaveAll();
    }
}