using ECart_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECart_BLL
{
    public class AccountService
    {
        private readonly AppUsersRepository appUsersRepository;
        public AccountService()
        {
            appUsersRepository = new AppUsersRepository();
        }
        public bool Authenticate(string userName, string password, out int userId)
        {
            userId = -1;
            bool Succeded = appUsersRepository.ValidateCredentials(userName, password);
            if (Succeded)
                userId = appUsersRepository.GetUserId(userName);
            return Succeded;
        }
    }
}
