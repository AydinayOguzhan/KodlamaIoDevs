using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Core.Security.Hashing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Authorizations.Rules
{
    public class AuthorizationBusinessRules
    {
        public void CheckIfUserExists(User user)
        {
            if (user == null) 
                throw new BusinessException("User not found");
        }

        public void CheckIfPasswordTrue(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            var result = HashingHelper.VerifyPasswordHash(password, passwordHash, passwordSalt);
            if (result == false) 
                throw new BusinessException("Password wrong");
            
        }
    }
}
