using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Project_Model.Entities
{
    public class User:BaseEntity
    {
        public string UserName { get; set; }
        public DateTime CreatTime { get; set; }
        public string Avatar { get; set; }
        public DateTime? UpdateTime { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsActive { get; set; }
        public UserStatuss UserStatus { get; set; } = UserStatuss.UnActive;
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public ICollection<Permission>? Permissions { get; set; }
        public ICollection<Order> Order { get; set; }
    }
    public enum UserStatuss
    {
        UnActive = 0,
        Active = 1,
    }
}
