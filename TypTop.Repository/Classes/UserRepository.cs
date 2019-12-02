using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TypTop.Database;
using System.Linq;


namespace TypTop.Repository
{
    class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(Context context) : base(context)
        {
        }

        public int GetId(string username)
        {
            return ((Context)DbContext).User
                .Where(u => u.Username.Equals(username))
                .Select(u => u.UserId).Single();
        }

        public DateTime GetLastLogin(int userId)
        {
            return ((Context)DbContext).User
                .Find(userId)
                .LastLogin;
        }

        public byte[] GetPasswordHash(string username)
        {
            return Convert.FromBase64String(
                ((Context)DbContext).User
                .Where(u => u.Username.Equals(username))
                .Single().Password);
        }

        public byte[] GetSalt(string username)
        {
            return Convert.FromBase64String(
                ((Context)DbContext).User
                .Where(u => u.Username.Equals(username))
                .Single().Salt);
        }

        public int? GetTeacherId(int userId)
        {
            return ((Context)DbContext).User.Find(userId).TeacherId;
        }

        public bool GetType(int userId)
        {
            return ((Context)DbContext).User.Find(userId).Teacher;
        }

    }
}
