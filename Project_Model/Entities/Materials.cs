using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Project_Model.Entities
{
    public class Materials:BaseEntity
    {
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<Product> products { get; set; }

    }
}
