using Project_Bussiness.Payloads.RequestModel.UserRequest;
using Project_Bussiness.Payloads.ResponseModel.DataUser;
using Project_Bussiness.Payloads.Responses;
using Project_Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Bussiness.IServices
{
    public interface IAuthServices
    {
        Task<ResponseObject<DataResponseUser>> Register(Request_Register request);
        Task<string> ConfirmRegisterAccount(string confirmCode);

        Task<ResponseObject<DataResponseLogin>> GetJWTTokenAsync(User user);

        Task<ResponseObject<DataResponseLogin>> Login(Request_Login request);

        Task<ResponseObject<DataResponseUser>> ChangePassword(int UserId, Request_ChangePassword request);
        //  Task<ResponseObject<DataResponseUser>> ChangePassword(string UserName, Request_ChangePassword request);

        Task<string> ForgotPassWord(string email);
        Task<string> ConfirmCreateNewPassWord(Request_CreateNewPassWord request);

        Task<string> AddRolesToUser(int userId, List<string> roles);
       Task<string> DeleteRoles(int userId, List<string> roles);

    }
}
