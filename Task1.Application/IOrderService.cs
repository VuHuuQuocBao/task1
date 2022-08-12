using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.ViewModel;
using Task1.ViewModel.Order;
using Task1.ViewModel.Pagination;

namespace Task1.Application
{
    public interface IOrderService
    {
        Task<PagedResult<OrderViewModel>> GetAll(PagedRequest request);

        Task<int> Create(OrderCreateRequest request);

        Task<int> Update(OrderUpdateRequest request);

        Task<int> Delete(int unitId);
    }
}