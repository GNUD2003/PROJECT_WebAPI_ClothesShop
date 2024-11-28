using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Model.Entities
{
    public class OrderDetail:BaseEntity
    {
        public int quantity {  get; set; }
        public float price { get; set; }

        public string img_product { get; set; }
        //  public Unit Unit {  get; set; }
        // public string Unit { get; set; }

        public Statuss status { get; set; }=Statuss.success;
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }    
    }
    public enum Statuss
    {
        cancel=0, success=1
    }

    public enum unit
    {
        cai=0,
        bo=1
    }
}
