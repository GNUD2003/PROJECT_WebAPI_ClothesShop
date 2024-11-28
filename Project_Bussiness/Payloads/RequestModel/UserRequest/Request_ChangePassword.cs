using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Bussiness.Payloads.RequestModel.UserRequest
{
    public class Request_ChangePassword
    {
        public string OldPassWord { get; set; }
        public string NewPassWord { get; set; }
        public string ConfirmPassWord { get; set; }
    }
}

