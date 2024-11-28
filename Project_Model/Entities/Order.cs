using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Model.Entities
{
    public class Order:BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public DateTime CreatDay { get; set; }
        public DateTime? UpdateTime { get; set; }    
        public string? Note { get; set; }
        public float TotalPrice { get; set; } = 0;
        public Status status { get; set; }=Status.Pending;
        public string Address {  get; set; }
        public string PhoneNumber { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
    public enum Status
    {
        Reject = 0,
        Pending=1,
        Approve = 2

    }
}
