using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Bussiness.Payloads.Responses
{
    public class ResponseObject<T>
    {
        public string Messege { get; set; }
        public int Status { get; set; }
        public T? Data { get; set; }
        public ResponseObject() { }

        public ResponseObject(string messege, int status, T? data)
        {
            Messege = messege;
            Status = status;
            Data = data;
        }
    }
}