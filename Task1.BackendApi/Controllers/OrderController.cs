using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task1.Application;
using Task1.Data.Entities;
using Task1.Utilities;
using Task1.ViewModel;
using Task1.ViewModel.Pagination;

namespace Task1.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)

        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPaging(PagedRequest request)
        {
            var result = await _orderService.GetAll(request);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderCreateRequest request)
        {
            var model = new OrderCreateRequest()
            {
                UnitId = request.UnitId,

                UnitName = request.UnitName,

                CustomerName = request.CustomerName,

                OrderDetails = request.OrderDetails,
            };
            try
            {
                var result = await _orderService.Create(model);
                return Ok(result);
            }
            catch (Task1Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("asdf");
            }

            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UnitUpdateRequest request)
        {
            var model = new UnitUpdateRequest()
            {
                Id = request.Id,
                UnitName = request.UnitName,
                BossName = request.BossName,
            };

            //var result = await _orderService.Update(model);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _orderService.Delete(id);
            return Ok(result);
        }
    }
}