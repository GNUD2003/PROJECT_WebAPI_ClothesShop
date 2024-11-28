using Project_Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Bussiness.Payloads.RequestModel
{
    public class OrderDetailRequest
    {
        public int quantity { get; set; }

        public string img_product { get; set; }
        
        //  public float price { get; set; }


    }
   /* public enum Unit
    {
        cai=0,
        bo=1
    }*/
}
