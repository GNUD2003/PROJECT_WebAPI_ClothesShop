using Project_Bussiness.Handle.HandleEmail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Bussiness.IServices
{
    public interface IEmailServices
    {
        string SendEmmail(EmailMessage emailMessage);

    }
}
