using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECart_DAL
{
    public class AppUsersRepository
    {
        private readonly ECartContext context;
        public AppUsersRepository()
        {
            context = new ECartContext();
        }
        public bool ValidateCredentials(string username, string password)
        {
            return context.Users.Any(user => user.UserName.Equals(username) && user.Password.Equals(password));
        }
        public int GetUserId(string username)
        {
            return context.Users.Single(user => user.UserName.Equals(username)).UserId;
        }
    }
}
