using Project_Bussiness.Page;
using Project_Bussiness.Payloads.RequestModel;
using Project_Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Bussiness.IServices
{
    public interface IOrderServices
    {
        Task<string> AddNewOrder(int UserId, OrderRequest request);

        Task<string> UpdateOrder(int id,OrderRequest request);
        Task<string> DeleteOrder(int id);
        Task<string> RejectOrder(int id);

        Task<string> ApproveOrder(int id);
        Task<IEnumerable<Order>> GetAllOrder();

        Task<PageResult<Order>> GetAllPagingPending(string? keyword, Pagination pagination);
        Task<PageResult<Order>> GetAllPagingReject(string? keyword, Pagination pagination);
        Task<PageResult<Order>> GetAllPagingApprove(string? keyword, Pagination pagination);

        Task<PageResult<OrderDetail>> GetAllHistoryOrder(string? keyword, Pagination pagination,int userId);

        Task<string> CanceltOrderDetail(int id);






    }
}
