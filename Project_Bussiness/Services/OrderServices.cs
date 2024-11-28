using MailKit.Search;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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
    public class OrderServices : IOrderServices
    {
        private readonly IDBContext _dbContext;
        private readonly AppDBContext _context;
        private readonly DbSet<Order> _dbSet;

        private readonly IBaseRepositoty<User> _userRepository;
        private readonly IBaseRepositoty<Order> _orderRepository;
        private readonly IBaseRepositoty<OrderDetail> _orderDetailRepository;
        private readonly IBaseRepositoty<Product> _productRepository;
        public OrderServices()
        {

        }
        public OrderServices(IDBContext dbContext, IBaseRepositoty<User> userRepository,
            IBaseRepositoty<Order> orderRepository, AppDBContext context, IBaseRepositoty<Product> productRepository,
        IBaseRepositoty<OrderDetail> orderDetailRepository) 
        { 

            
            _dbContext = dbContext;
            _userRepository = userRepository;
            _orderRepository = orderRepository;
            _context = context;
            _orderDetailRepository = orderDetailRepository;
            _productRepository = productRepository;
        }

        public async Task<string> AddNewOrder(int UserId, OrderRequest request)
        {
            var checkUser= await _userRepository.GetByIdAsync(UserId);
            if(checkUser == null)
            {
                return "Nguoi dung chua dang ki mua hang";
            }
           
            else
            {
                var today = DateTime.Now.ToString("yyyyMMdd");

                var orderCountTody = await GetOrderCountByDateAsync(today);

                var orderCode = $"ORD-{today}-{(orderCountTody + 1):D4}";

                Order order = new Order()

                {
                    
                    Name = request.Name,
                    Code = orderCode,
                    Note = request.Note,
                    CreatDay = DateTime.Now,
                    TotalPrice = request.TotalPrice,
                    Address = request.Address,
                    PhoneNumber=request.PhoneNumber,
                    UserId = UserId,

                };
                await _orderRepository.CreateAsync(order);
                return "Them thanh cong don hang moi";
            }
        }
       /* public async Task<string> CreateNewOrder(int UserId, List<OrderDetailRequest> orderDetails,
            OrderRequest request)
        {
            var checkUser = await _userRepository.GetByIdAsync(UserId);
            if (checkUser == null)
            {
                return "Nguoi dung chua dang ki mua hang";
            }

            else
            {
                var today = DateTime.Now.ToString("yyyyMMdd");

                var orderCountTody = await GetOrderCountByDateAsync(today);

                var orderCode = $"ORD-{today}-{(orderCountTody + 1):D4}";

                Order order = new Order()

                {

                    Name = request.Name,
                    Code = orderCode,
                    Note = request.Note,
                    CreatDay = DateTime.Now,
                    TotalPrice = request.TotalPrice,
                    Address = request.Address,
                    PhoneNumber = request.PhoneNumber,
                    UserId = UserId,

                };
                await _orderRepository.CreateAsync(order);

                foreach(var detail in orderDetails)
                {
                    var product = await _productRepository.GetByIdAsync(detail.productId);

                    if(product == null)
                    {
                        return "Product not exist";
                    }
                    if(product.countOfProduct < detail.quantity)
                    {
                        return "product not enough";
                    }

                    OrderDetail orderdetail = new OrderDetail
                    {
                        OrderId = order.Id, // Gắn vào Order vừa tạo
                        ProductId = detail.productId,
                        quantity = detail.quantity,
                        price = product.price * detail.quantity,
                        *//*TotalPrice = detail.Quantity * product.Price*//*
                    };

                    await _orderDetailRepository.CreateAsync(orderdetail);
                }

                return "Them thanh cong don hang moi";
            }
        }*/

        public async Task<int> GetOrderCountByDateAsync(string date)
        {
            // Parse date từ chuỗi nếu cần
            DateTime parsedDate = DateTime.ParseExact(date, "yyyyMMdd", null);
            if (_context.Orders == null)
            {
                throw new InvalidOperationException("Orders DbSet is null.");
            }

            // Đếm số đơn hàng trong ngày hiện tại
            return await _context.Orders
                .Where(o => o.CreatDay.Date == parsedDate.Date) // So sánh theo ngày
                .CountAsync();
        }

        public async Task<string> DeleteOrder(int id)
        {
            await _orderRepository.DeleteAsync(id);
            return "Xoa thanh cong";
        }

        public async Task<IEnumerable<Order>> GetAllOrder()
        {
            var list = await _orderRepository.GetAllAsync();
            return list;
        }

       

        public async Task<string> UpdateOrder(int id, OrderRequest request)
        {
            var check = await _orderRepository.GetAsync(x => x.Id == id);
            if (check == null)
            {
                return "khong tim thay don hang ";
            }
            else
            {
                check.Name = request.Name;
               
                check.Note = request.Note;
                check.UpdateTime = DateTime.Now;

                await _orderRepository.UpdateASync(check);

                return "Update thanh cong";
            }
        }
        public async Task<PageResult<Order>> GetAllPagingPending(string? keyword, Pagination pagination)
        {
            var list1 = await _orderRepository.GetAllAsync();
            var list = list1.Where(order => order.status == Status.Pending);

            if (!string.IsNullOrEmpty(keyword))
            {
                list = list.Where(x => x.Name.ToLower().Contains(keyword.ToLower()));
            }
            pagination.TotalCount = list.Count();
            var result = PageResult<Order>.ToPageResult(pagination, list);
            return new PageResult<Order>(pagination, result);
        }

        public async Task<PageResult<Order>> GetAllPagingReject(string? keyword, Pagination pagination)
        {
            var list1 = await _orderRepository.GetAllAsync();
            var list = list1.Where(order => order.status == Status.Reject);

            if (!string.IsNullOrEmpty(keyword))
            {
                list = list.Where(x => x.Name.ToLower().Contains(keyword.ToLower()));
            }
            pagination.TotalCount = list.Count();
            var result = PageResult<Order>.ToPageResult(pagination, list);
            return new PageResult<Order>(pagination, result);
        }

        public async Task<PageResult<Order>> GetAllPagingApprove(string? keyword, Pagination pagination)
        {
            var list1 = await _orderRepository.GetAllAsync();
            var list = list1.Where(order => order.status == Status.Approve);

            if (!string.IsNullOrEmpty(keyword))
            {
                list = list.Where(x => x.Name.ToLower().Contains(keyword.ToLower()));
            }
            pagination.TotalCount = list.Count();
            var result = PageResult<Order>.ToPageResult(pagination, list);
            return new PageResult<Order>(pagination, result);
        }
        public async Task<PageResult<OrderDetail>> GetAllHistoryOrder(string? keyword, Pagination pagination, int userId)
        {
            IQueryable<Order> query = _context.Orders.AsQueryable();
            query = query.Where(order => order.UserId == userId);

            // Nếu có từ khóa, lọc thêm theo từ khóa
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(order => order.Name.Contains(keyword) || order.Note.Contains(keyword));
            }

            // Lấy danh sách OrderId
            var orders = await query.ToListAsync();
            var orderIds = orders.Select(o => o.Id).ToList();

            // Lấy danh sách OrderDetails liên quan đến các OrderId
            var orderDetailsQuery = _context.OrderDetails.AsQueryable();
            var filteredOrderDetails = orderDetailsQuery.Where(od => orderIds.Contains(od.OrderId) && od.status==Statuss.success).OrderByDescending(od => od.Id); ;

            // Tính tổng số lượng OrderDetail
            // pagination.TotalCount = await filteredOrderDetails.CountAsync();

            pagination.TotalCount = filteredOrderDetails.Count();
            var result = PageResult<OrderDetail>.ToPageResult(pagination, filteredOrderDetails);
            return new PageResult<OrderDetail>(pagination, result);


        }


        public async Task<string> ApproveOrder(int id)
        {
           var oder= await _orderRepository.GetByIdAsync(id);
            if(oder == null)
            {
                return "Order not exist";
            }
            
            oder.status= Status.Approve;
            await _orderRepository.UpdateASync(oder);
            return "Order was approved";
        }

        public async Task<string> RejectOrder(int id)
        {
            var oder = await _orderRepository.GetByIdAsync(id);
            if (oder == null)
            {
                return "Order not exist";
            }

            oder.status = Status.Reject;
            await _orderRepository.UpdateASync(oder);
            return "Order was reject";
        }

        public async Task<string> CanceltOrderDetail(int id)
        {
           var orderDt= await _orderDetailRepository.GetByIdAsync(id);
            if (orderDt == null)
            {
                return "Order Detail not exist";
            }

            orderDt.status = Statuss.cancel;
            await _orderDetailRepository.UpdateASync(orderDt);
            return "Cancal succesfful";
        }
    }
}
