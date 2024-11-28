using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Project_Model.Entities
{
    public class Product:BaseEntity
    {
        public string name { get; set; }

        public float price { get; set; }
        public string description { get; set; }

        public int IsActive { get; set; } = 1;

        public int countOfProduct { get; set; } = 0;

        public string? img_product {  get; set; }



        public int  CateId { get; set; }
        [JsonIgnore]
        public Category Cate { get; set; }
        public int MateId { get; set; }
        [JsonIgnore]
        public Materials Mate { get; set; }
    }
}
