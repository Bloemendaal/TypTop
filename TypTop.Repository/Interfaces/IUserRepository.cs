using System;
using System.Collections.Generic;
using System.Text;
using TypTop.Database;

namespace TypTop.Repository
{
    interface IUserRepository : IRepository<User>
    {

        public int GetId(string username);
        byte[] GetPasswordHash(string username);
        byte[] GetSalt(string username);
        DateTime GetLastLogin(int userId);
        bool GetType(int userId);
        int? GetTeacherId(int userId);
    }
}
