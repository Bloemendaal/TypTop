using Konscious.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace TypTop.LoginGui
{
    public static class PasswordHasher
    {

        /// <summary>
        /// Creates a salt to be used in HashPassword and VerifyHash
        /// </summary>
        public static byte[] CreateSalt()
        {
            var buffer = new byte[16];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(buffer);
            rng.Dispose();
            return buffer;
        }

        /// <summary>
        /// Generate a hash using Argon2id based on the password
        /// </summary>
        public static byte[] HashPassword(string password, byte[] salt)
        {
            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password))
            {
                Salt = salt,
                DegreeOfParallelism = 4,
                Iterations = 4,
                MemorySize = 1024 * 100
            };

            var r = argon2.GetBytes(1024);
            argon2.Dispose();
            return r;
        }

        /// <summary>
        /// Verify that an entered password matches the stored hash.
        /// </summary>
        public static bool VerifyHash(string password, byte[] salt, byte[] hash)
        {
            var newHash = HashPassword(password, salt);
            return hash.SequenceEqual(newHash);
        }

    }
}
