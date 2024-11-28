using Project_Bussiness.Payloads.ResponseModel.DataUser;
using Project_Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Bussiness.Payloads.Mappers
{
    public class UserConverter
    {
        public DataResponseUser EntityToDTO(User user)
        {
            return new DataResponseUser
            {
                Id = user.Id,
                Avatar = user.Avatar,
                UpdateTime = user.UpdateTime,
                FullName = user.FullName,
                DateOfBirth = user.DateOfBirth,
                //IsActive =
                UserStatus = user.UserStatus.ToString(),
                CreatTime = user.CreatTime,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,


            };
        }
    }
}