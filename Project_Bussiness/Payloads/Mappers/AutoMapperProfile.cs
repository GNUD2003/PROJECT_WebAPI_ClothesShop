using AutoMapper;
using Project_Bussiness.Payloads.RequestModel.UserRequest;
using Project_Bussiness.Payloads.ResponseModel.DataUser;
using Project_Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Bussiness.Payloads.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Request_Register, User>();
            CreateMap<User, DataResponseUser>();

        }
    }
}