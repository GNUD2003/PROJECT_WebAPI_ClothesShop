using Microsoft.EntityFrameworkCore;
using Project_Bussiness.IServices;
using Project_Bussiness.Page;
using Project_Bussiness.Payloads.RequestModel;
using Project_Data.Data;
using Project_Model.Entities;
using Project_Model.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Bussiness.Services
{
    public class OrderDetailServices : IOrderDetailServices
    {
        private readonly IDBContext _dbContext;

        private readonly IBaseRepositoty<Product> _productRepository;
        private readonly IBaseRepositoty<Order> _orderRepository;
        private readonly IBaseRepositoty<OrderDetail> _orderDetailRepository;
        private readonly AppDBContext _context;
        public OrderDetailServices()
        {

        }
        public OrderDetailServices(IDBContext dbContext, IBaseRepositoty<OrderDetail> orderDetailRepository, 
            IBaseRepositoty<Order> orderRepository, IBaseRepositoty<Product> productRepository,AppDBContext context)
        {
            _dbContext = dbContext;
            _productRepository = productRepository;
            _orderRepository = orderRepository; 
            _orderDetailRepository = orderDetailRepository;
            _context = context;

        }

        /* public async Task<string> AddNewListOrderDetail(int OrderId, int ProductId, List<OrderDetailRequest> ListRequest)
         {

         }*/

        /* public async Task<string> AddNewOrderDetail(int OrderId, int ProductId, OrderDetailRequest request)
         {
             var checkOrder= await _orderRepository.GetByIdAsync(OrderId);
             if (checkOrder == null)
             {
                 return "Don hang khong ton tai";
             }
             else
             {
                 var checkProduct= await _productRepository.GetByIdAsync(ProductId);
                 if(checkProduct == null)
                 {
                     return "San pham khong ton tai";
                 }
                 else
                 {
                     OrderDetail od = new OrderDetail()
                     {
                         quantity = request.quantity,
                         price = request.quantity * checkProduct.price,
                       //  Unit = request.unit,
                         OrderId=OrderId,
                         ProductId=ProductId
                     };
                     await _orderDetailRepository.CreateAsync(od);

                  *//*   checkOrder.TotalPrice += od.price;
                     _orderRepository.UpdateASync(checkOrder);*//*

                     return "Them san pham vao don hang thanh cong";
                 }
             }
         }*/

        /* public async Task<string> AddNewOrderDetail(List<int> productId, OrderDetailRequest request)
         {
             // Lấy OrderId từ đơn hàng gần nhất
             var latestOrder = await GetLatestOrderAsync();
             if (latestOrder == null)
             {
                 return "Không tìm thấy đơn hàng.";
             }
             var orderId = latestOrder.Id;

             // Kiểm tra đơn hàng
             var checkOrder = await _orderRepository.GetByIdAsync(orderId);
             if (checkOrder == null)
             {
                 return "Đơn hàng không tồn tại.";
             }

             // Kiểm tra sản phẩm
             var checkProduct = await _productRepository.GetByIdAsync(productId);
             if (checkProduct == null)
             {
                 return "Sản phẩm không tồn tại.";
             }

             // Tạo chi tiết đơn hàng
             OrderDetail od = new OrderDetail
             {
                 quantity = request.quantity,
                 price = request.quantity * checkProduct.price,
                 OrderId = orderId,
                 ProductId = productId
             };

             await _orderDetailRepository.CreateAsync(od);

             // Cập nhật tổng giá đơn hàng


             return "Thêm sản phẩm vào đơn hàng thành công.";
         }*/

        public async Task<string> AddNewOrderDetail(List<int> productIds, List<OrderDetailRequest> requests)
        {
            // Kiểm tra xem số lượng productIds và requests có khớp không
            if (productIds == null || requests == null || productIds.Count != requests.Count)
            {
                return "Invalid request: Ensure productIds and requests have matching count.";
            }

            // Lấy OrderId từ đơn hàng gần nhất
            var latestOrder = await GetLatestOrderAsync();
            if (latestOrder == null)
            {
                return "Không tìm thấy đơn hàng.";
            }
            var orderId = latestOrder.Id;

            // Kiểm tra đơn hàng
            var checkOrder = await _orderRepository.GetByIdAsync(orderId);
            if (checkOrder == null)
            {
                return "Đơn hàng không tồn tại.";
            }

            // Lặp qua danh sách productId và requests đồng thời
            for (int i = 0; i < productIds.Count; i++)
            {
                var productId = productIds[i];
                var request = requests[i];

                // Kiểm tra sản phẩm
                var checkProduct = await _productRepository.GetByIdAsync(productId);
                if (checkProduct == null)
                {
                    return $"Sản phẩm với ID {productId} không tồn tại.";
                }

                // Tạo chi tiết đơn hàng cho từng sản phẩm
                OrderDetail od = new OrderDetail
                {
                    quantity = request.quantity, // Lấy số lượng từ request tương ứng
                    price = request.quantity * checkProduct.price, // Tính giá dựa trên số lượng
                    OrderId = orderId,
                    ProductId = productId,
                    img_product=request.img_product,
                };
                if (checkProduct.countOfProduct <= request.quantity)
                    return "Het hang";
                else
                {

                    checkProduct.countOfProduct -= request.quantity;
                    await _productRepository.UpdateASync(checkProduct);

                    // Lưu chi tiết đơn hàng vào cơ sở dữ liệu
                    await _orderDetailRepository.CreateAsync(od);
                }
            }
            return "Thêm sản phẩm vào đơn hàng thành công.";
        }

        public async Task<Order> GetLatestOrderAsync()
        {
            // Lấy đơn hàng mới nhất dựa trên Id
            var latestOrder = await _context.Orders
                .OrderByDescending(o => o.Id)
                .FirstOrDefaultAsync();

            if (latestOrder == null)
            {
                Console.WriteLine("Không tìm thấy đơn hàng nào trong cơ sở dữ liệu.");
                return null; // Hoặc throw Exception nếu muốn
            }

            return latestOrder;
        }

        public async Task<string> DeleteOrderDetail(int id)
        {
            await _orderDetailRepository.DeleteAsync(id);
            return "Xoa thanh cong";
        }

        public async Task<IEnumerable<OrderDetail>> GetAllOrderDetail()
        {
            var list = await _orderDetailRepository.GetAllAsync();
            return list;
        }

        public async Task<string> UpdateOrderDetail(int id, OrderDetailRequest request)
        {
            var check= await _orderDetailRepository.GetByIdAsync(id);
            if(check == null)
            {
                return "Khong tim thay chi tiet don hang";
            }
            else
            {
                var checkProduct= await _productRepository.GetByIdAsync(check.ProductId);
                var checkOrder = await _orderRepository.GetByIdAsync(check.OrderId);
                check.quantity= request.quantity;   
                check.price=request.quantity * checkProduct.price;
                // check.Unit=,

                await _orderDetailRepository.UpdateASync(check);

                checkOrder.UpdateTime=DateTime.Now;
                await _orderRepository.UpdateASync(checkOrder);

                return "Update chi tiet don hang thanh cong";
 
            }
        }

        public async Task<IEnumerable<OrderDetail>> GetAllOrderDetailByOrderId(int orderId)
        {
            // Kiểm tra đơn hàng có tồn tại hay không
            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order == null)
            {
                throw new ArgumentException($"Order with ID {orderId} does not exist.");
            }

            // Lấy danh sách chi tiết đơn hàng liên quan đến OrderId
            var orderDetails = await _orderDetailRepository.GetAllAsync(od => od.OrderId == orderId && od.status==Statuss.success);
            return orderDetails;
        }

        public async Task<PageResult<OrderDetail>> GetAllOrderDetailPaging(string? keyword, Pagination pagination, int orderId)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order == null)
            {
                throw new ArgumentException($"Order with ID {orderId} does not exist.");
            }

            // Lấy danh sách chi tiết đơn hàng liên quan đến OrderId
            var list = await _orderDetailRepository.GetAllAsync(od => od.OrderId == orderId && od.status == Statuss.success);


           /* if (!string.IsNullOrEmpty(keyword))
            {
                list = list.Where(x => x..ToLower().Contains(keyword.ToLower()));
            }*/
            pagination.TotalCount = list.Count();
            var result = PageResult<OrderDetail>.ToPageResult(pagination, list);
            return new PageResult<OrderDetail>(pagination, result);

        }

        public Task<string> CanceltOrderDetail(int id)
        {
            throw new NotImplementedException();
        }
    }
}
