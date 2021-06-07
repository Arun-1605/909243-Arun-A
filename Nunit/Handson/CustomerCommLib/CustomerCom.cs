using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCommLib
{
    public class CustomerCom
    {
        IMailSender _mailSender;

        public CustomerCom(IMailSender mailSender)
        {
            _mailSender = mailSender;
        }
        public bool SendMailCustomer()
        {
            _mailSender.SendMail("cust123@abc.com", "Some Message");

            return true;
        }

    }
}

