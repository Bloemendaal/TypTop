using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TypTop.Database;


namespace TypTop.Repository
{
    class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(Context context) : base(context)
        {
        }

        public int GetId(string username)
        {
            throw new NotImplementedException();
        }

        public DateTime GetLastLogin(int userId)
        {
            throw new NotImplementedException();
        }

        public byte[] GetPasswordHash(string username)
        {
            throw new NotImplementedException();
        }

        public byte[] GetSalt(string username)
        {
            throw new NotImplementedException();
        }

        public int GetTeacherId(int userId)
        {
            throw new NotImplementedException();
        }

        public bool GetType(int userId)
        {
            throw new NotImplementedException();
        }

    }
}
