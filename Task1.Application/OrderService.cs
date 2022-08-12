using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Data.Entities;
using Task1.Data.EntityFramework;
using Task1.Utilities;
using Task1.ViewModel;
using Task1.ViewModel.Order;
using Task1.ViewModel.Pagination;

namespace Task1.Application
{
    public class OrderService : IOrderService
    {
        private readonly Task1DbContext _context;

        public OrderService(Task1DbContext context)
        {
            _context = context;
        }

        public OrderService()
        {
        }

        public async Task<int> Create(OrderCreateRequest request)
        {
            var unit = await _context.Units.FindAsync(request.UnitId);
            if (unit == null) throw new Task1Exception($"May la ai? ");

            var order = new Order()
            {
                UnitId = request.UnitId,
                UnitName = request.UnitName,
                CustomerName = request.CustomerName,
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            var orderId = order.Id;

            List<OrderDetail> listOrderDetailWithOrderId = new List<OrderDetail>();

            foreach (var item in request.OrderDetails)
            {
                var orderDetailWithOrderId = new OrderDetail()
                {
                    OrderId = orderId,
                    ProductName = item.ProductName,
                    Quantity = item.Quantity,
                };
                listOrderDetailWithOrderId.Add(orderDetailWithOrderId);
            }

            _context.OrderDetails.AddRange(listOrderDetailWithOrderId);
            await _context.SaveChangesAsync();
            return orderId;
        }

        public Task<int> Delete(int unitId)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResult<OrderViewModel>> GetAll(PagedRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(OrderUpdateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}