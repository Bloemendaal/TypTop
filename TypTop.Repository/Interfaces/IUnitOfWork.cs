using System;

namespace TypTop.Repository
{
    interface IUnitOfWork : IDisposable
    {

        public IUserRepository Users { get;}
        public IWordRepository Words { get; }
        public ILevelRepository Levels { get; }
        public IWorldRepository Worlds { get; }
        int Complete();
    }
}
