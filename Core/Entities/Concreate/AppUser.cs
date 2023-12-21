using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concreate
{
    public class AppUser
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public DateTime TokenExpiredDate { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public bool EmailConfirmed { get; set; }
        public int LoginAttempt { get; set; }
        public DateTime loginAttemptExpired { get; set; }
    }
}
