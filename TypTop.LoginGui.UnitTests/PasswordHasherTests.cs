using System;
using NUnit.Framework;

namespace TypTop.LoginGui.UnitTests
{
    [TestFixture]
    public class PasswordHasherTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CreateSalt_RunMultipleTimes_ReturnsDifferentValue()
        {
            var salt1 = PasswordHasher.CreateSalt();
            var salt2 = PasswordHasher.CreateSalt();
            var salt3 = PasswordHasher.CreateSalt();

            Assert.AreNotEqual(salt1, salt2);
            Assert.AreNotEqual(salt1, salt3);
            Assert.AreNotEqual(salt2, salt3);
        }


        [Test]
        public void HashPassword_EmptyString_ThrowsException()
        {
            Assert.Throws<ArgumentException>(delegate
            {
                PasswordHasher.HashPassword("", PasswordHasher.CreateSalt());
            });
        }

        [Test]
        public void HashPassword_StringOfLength10AndDifferentSalt_DifferentResult()
        {
            var password = "MyPassword";

            var hash1 = PasswordHasher.HashPassword(password, PasswordHasher.CreateSalt());
            var hash2 = PasswordHasher.HashPassword(password, PasswordHasher.CreateSalt());
            var hash3 = PasswordHasher.HashPassword(password, PasswordHasher.CreateSalt());

            Assert.AreNotEqual(hash1, hash2);
            Assert.AreNotEqual(hash1, hash3);
            Assert.AreNotEqual(hash2, hash3);
        }


        [Test]
        public void HashPassword_StringOfLength10AndSameSalt_AlwaysHasSameResult()
        {
            var password = "MyPassword";
            var salt = PasswordHasher.CreateSalt();

            var hash1 = PasswordHasher.HashPassword(password, salt);
            var hash2 = PasswordHasher.HashPassword(password, salt);
            var hash3 = PasswordHasher.HashPassword(password, salt);

            Assert.AreEqual(hash1, hash2);
            Assert.AreEqual(hash1, hash3);
        }

        [Test]
        public void VerifyHash_CorrectPasswordDifferentSalt_ReturnsFalse()
        {
            var password = "MyPassword";
            var passwordHash = PasswordHasher.HashPassword(password, PasswordHasher.CreateSalt());

            var result = PasswordHasher.VerifyHash(password, PasswordHasher.CreateSalt(), passwordHash);

            Assert.IsFalse(result);
        }

        [Test]
        public void VerifyHash_CorrectPasswordSameSalt_ReturnsTrue()
        {
            var password = "MyPassword";
            var salt = PasswordHasher.CreateSalt();
            var passwordHash = PasswordHasher.HashPassword(password, salt);

            var result = PasswordHasher.VerifyHash(password, salt, passwordHash);

            Assert.IsTrue(result);
        }

        [Test]
        public void VerifyHash_WrongPasswordDifferentSalt_ReturnsFalse()
        {
            var password = "MyPassword";
            var salt1 = PasswordHasher.CreateSalt();
            var passwordHash = PasswordHasher.HashPassword(password, salt1);
            var salt2 = PasswordHasher.CreateSalt();
            var wrongPassword = "NotMyPassword";

            var result = PasswordHasher.VerifyHash(wrongPassword, salt2, passwordHash);

            Assert.IsFalse(result);
        }

        [Test]
        public void VerifyHash_WrongPasswordSameSalt_ReturnsFalse()
        {
            var password = "MyPassword";
            var salt = PasswordHasher.CreateSalt();
            var passwordHash = PasswordHasher.HashPassword(password, salt);
            var wrongPassword = "NotMyPassword";

            var result = PasswordHasher.VerifyHash(wrongPassword, salt, passwordHash);

            Assert.IsFalse(result);
        }
    }
}