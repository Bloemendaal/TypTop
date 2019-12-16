using System;

namespace TypTop.Repository
{
    internal interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }

        int Complete();
    }
}