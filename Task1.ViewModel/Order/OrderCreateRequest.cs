using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Data.Entities;
using Task1.ViewModel.Special;

namespace Task1.ViewModel
{
    public class OrderCreateRequest
    {
        public int UnitId { get; set; }

        public string UnitName { get; set; }

        public string CustomerName { get; set; }

        public List<OrderDetailRequest> OrderDetails { get; set; }
    }
}