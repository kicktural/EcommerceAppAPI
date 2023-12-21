using Core.Utilities.Security.Hashing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTesting
{
    [TestFixture]
    public class PasswordTest
    {
        [Test]
        public void CheckUserSuccessPassword()
        {
            HashingHelper.HashPassword("user123", out byte[] passwordHash, out byte[] passwordSalt);
            var data = HashingHelper.VerifyPassword("user123", passwordHash, passwordSalt);
            Assert.True(data);
        }
        [Test]
        public void CheckUserWrongPassword()
        {
            HashingHelper.HashPassword("user1234", out byte[] passwordHash, out byte[] passwordSalt);
            var data = HashingHelper.VerifyPassword("user123", passwordHash, passwordSalt);
            Assert.False(data);
        }
    }
}
