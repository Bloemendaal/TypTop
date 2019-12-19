using System;
using System.Collections.Generic;
using System.Text;
using TypTop.Database;


namespace TypTop.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _context;
        public IUserRepository Users { get; private set; }
        public IWordRepository Words { get; private set; }
        public ILevelRepository Levels { get; private set; }

        public UnitOfWork(Context context)
        {
            _context = context;
            Users = new UserRepository(_context);
            Words = new WordRepository(_context);
            Levels = new LevelRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
