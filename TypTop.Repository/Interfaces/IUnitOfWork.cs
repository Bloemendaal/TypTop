using System;

namespace TypTop.Repository
{
    interface IUnitOfWork : IDisposable
    {

        public IUserRepository Users { get;}

        int Complete();
    }
}
