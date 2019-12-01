using System;
using System.Collections.Generic;
using System.Text;
using TypTop.Database;


namespace TypTop.Repository
{
    class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;
        public IUserRepository Users { get; private set; }

        public UnitOfWork(Context context)
        {
            _context = context;
            Users = new UserRepository(_context);
        }

        public int Complete()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
