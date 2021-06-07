using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace AuthenticationService.Models
{
    public class AuthRepository
    {
         readonly AuthContext context;
        public AuthRepository()
        {
            context = new AuthContext();
        }

        public bool ValidateCredentials(string username, string password)
        {
            return context.ApplicationUsers.Any(user => user.UserName.Equals(username) 
                                                 && user.Password.Equals(password));
        }
    }
}