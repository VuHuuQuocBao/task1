using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task1.Application;
using Task1.ViewModel;
using Task1.ViewModel.Pagination;

namespace Task1.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitController : Controller
    {
        private readonly IUnitService _unitService;

        public UnitController(IUnitService unitService)

        {
            _unitService = unitService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPaging(PagedRequest request)
        {
            var result = await _unitService.GetAll(request);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(UnitCreateRequest request)
        {
            var model = new UnitCreateRequest()
            {
                UnitName = request.UnitName,
                BossName = request.BossName,
            };

            var result = await _unitService.Create(model);
            return Ok(result);
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

            var result = await _unitService.Update(model);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _unitService.Delete(id);
            return Ok(result);
        }
    }
}