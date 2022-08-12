using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Data.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Unit")]
        public int UnitId { get; set; }

        [Required]
        public string UnitName { get; set; }

        [Required]
        public string CustomerName { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }

        public Unit Unit { get; set; }
    }
}