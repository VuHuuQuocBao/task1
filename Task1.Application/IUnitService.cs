using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.ViewModel;
using Task1.ViewModel.Pagination;
using Task1.ViewModel.Unit;

namespace Task1.Application
{
    public interface IUnitService
    {
        // search theo keyword implement sau
        //Task<PagedResult<UnitViewModel>> GetAllPaging(   request);

        // search theo Id implement sau
        //Task<UnitViewModel> GetById(int unitId);

        Task<PagedResult<UnitViewModel>> GetAll(PagedRequest request);

        Task<int> Create(UnitCreateRequest request);

        Task<int> Update(UnitUpdateRequest request);

        Task<int> Delete(int unitId);
    }
}