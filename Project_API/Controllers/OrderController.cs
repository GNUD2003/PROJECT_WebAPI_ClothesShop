using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_Bussiness.IServices;
using Project_Bussiness.Page;
using Project_Bussiness.Payloads.RequestModel;
using Project_Model.Entities;

namespace Project_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderServices _service;
        private readonly IOrderDetailServices _detailServices;
        public OrderController(IOrderServices service, IOrderDetailServices detailServices)
        {
            _service = service;
            _detailServices = detailServices;
        }
        [HttpPost("AddNewOrder/{userId}")]
        public async Task<IActionResult> AddNewProduct([FromRoute] int userId, [FromBody] OrderRequest request)
        {
            return Ok(await _service.AddNewOrder(userId, request));
        }



        [HttpPost("AddNewOrderDetail")]
        public async Task<IActionResult> AddOrderDetaiol([FromQuery] List<int> products, [FromBody] List<OrderDetailRequest> details)
        {
            if (products == null || details == null || products.Count != details.Count)
            {
                return BadRequest("Invalid request: Ensure products and details have matching count.");
            }

            return Ok(await _detailServices.AddNewOrderDetail(products, details));
        }

        [HttpGet("GetAllOrder")]
        public async Task<IActionResult> GetAllOrder()
        {
            return Ok(await _service.GetAllOrder());
        }

        [HttpGet("GetAllOrderPaging")]
        public async Task<IActionResult> GetListPage([FromQuery] string? keyword, [FromQuery] Pagination pagination)
        {
            return Ok(await _service.GetAllPagingPending(keyword, pagination));
        }

        [HttpGet("GetAllOrderRejectPaging")]
        public async Task<IActionResult> GetListPageReject([FromQuery] string? keyword, [FromQuery] Pagination pagination)
        {
            return Ok(await _service.GetAllPagingReject(keyword, pagination));
        }

        [HttpGet("GetAllOrderApprovePaging")]
        public async Task<IActionResult> GetListPageApprove([FromQuery] string? keyword, [FromQuery] Pagination pagination)
        {
            return Ok(await _service.GetAllPagingApprove(keyword, pagination));
        }



        /* GetAllOrderDetailPaging*/
        [HttpGet("GetAllOrderDetailPaging")]
        public async Task<IActionResult> GetLisODtPage([FromQuery] string? keyword, [FromQuery] Pagination pagination, [FromQuery] int id)
        {
            return Ok(await _detailServices.GetAllOrderDetailPaging(keyword, pagination,id));
        }

        /* GetAllOrderDetailPaging*/
        [HttpGet("GetAllHistoryPaging")]
        public async Task<IActionResult> GetAllHistoryOrder([FromQuery] string? keyword, [FromQuery] Pagination pagination, [FromQuery] int id)
        {
            return Ok(await _service.GetAllHistoryOrder(keyword, pagination, id));
        }

        [HttpPut("RejectOrderById/{id}")]
        public async Task<IActionResult> RejectOrder([FromRoute] int id)
        {
            return Ok(await _service.RejectOrder(id));
        }

        [HttpPut("ApproveOrderById/{id}")]
        public async Task<IActionResult>ApproveOrder([FromRoute] int id)
        {
            return Ok(await _service.ApproveOrder(id));
        }

        [HttpPut("CancelOrderDetail/{id}")]
        public async Task<IActionResult> CancelOrderDetail([FromRoute] int id)
        {
            return Ok(await _service.CanceltOrderDetail(id));
        }

    }
}
