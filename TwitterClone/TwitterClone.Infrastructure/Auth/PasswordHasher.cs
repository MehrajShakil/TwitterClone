using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterClone.Application.Interfaces;

namespace TwitterClone.Infrastructure.Auth
{
    public class PasswordHasher : IPasswordHasher
    { 
        public bool VerifyPassword(string password, string passwordHash)
        {
            // verify password.

            return true;
        }
    }
}
