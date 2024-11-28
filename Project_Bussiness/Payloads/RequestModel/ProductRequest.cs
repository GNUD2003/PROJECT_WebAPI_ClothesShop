using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Bussiness.Payloads.RequestModel
{
    public class ProductRequest
    {
       /* public string img_product { get; set; }*/
        public string name { get; set; }

        public float price { get; set; }
        public string description { get; set; }

        public int countOfProduct { get; set; }
    }
}
