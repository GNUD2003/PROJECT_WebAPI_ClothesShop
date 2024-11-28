using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Bussiness.Payloads.RequestModel
{
    public class OrderRequest
    {
        public string Name { get; set; }
      
        public string? Note { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public float TotalPrice { get; set; }



    }
}
