using System;

namespace SharedKernel.Interfaces
{
    public interface IUow : IDisposable
    {
        void Save();
    }
}