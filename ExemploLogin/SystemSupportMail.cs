using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploLogin
{
    public class SystemSupportMail : MasterMailServer
    {
        public SystemSupportMail() {
            senderMail = "davidwallacem@hotmail.com";
            password = "M@ng&ky0";
            host = "smtp-mail.outlook.com";
            port = 587;
            ssl = true;
            initializeSmtpClient();
        }
    }
}
