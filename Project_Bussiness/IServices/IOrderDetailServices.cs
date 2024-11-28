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
    public interface IOrderDetailServices
    {
        // Task<string> AddNewOrderDetail(int? OrderId, int ProductId, OrderDetailRequest request);
        //  Task<string> AddNewListOrderDetail(int OrderId, int ProductId,List< OrderDetailRequest> ListRequest);

        // Task<string> AddNewOrderDetail(int productId, OrderDetailRequest request);

        Task<string> AddNewOrderDetail(List<int> productIds, List<OrderDetailRequest> requests);
        Task<string> UpdateOrderDetail(int id, OrderDetailRequest request);
        Task<string> DeleteOrderDetail(int id);

        Task<IEnumerable<OrderDetail>> GetAllOrderDetail();
        Task<IEnumerable<OrderDetail>> GetAllOrderDetailByOrderId(int orderId);

        Task<PageResult<OrderDetail>> GetAllOrderDetailPaging(string? keyword, Pagination pagination,int orderId);

        Task<string> CanceltOrderDetail(int id);
    }
}
