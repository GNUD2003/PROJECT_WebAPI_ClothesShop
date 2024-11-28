using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Bussiness.Payloads.ResponseModel.DataUser
{
    public class DataResponseUser : DataResponseBase
    {

        public DateTime CreatTime { get; set; }
        public string Avatar { get; set; }
        public DateTime? UpdateTime { get; set; }
        public string PhoneNumber { get; set; }

        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        // public bool IsActive { get; set; }
        public string UserStatus { get; set; }
        public string Email { get; set; }

    }
}
