using System;
using TypTop.Database;

namespace TypTop.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        int GetId(string username);
        byte[] GetPasswordHash(string username);
        byte[] GetSalt(string username);
        DateTime GetLastLogin(int userId);
        bool GetType(int userId);
        int? GetTeacherId(int userId);
    }
}