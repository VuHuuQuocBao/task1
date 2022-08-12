using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Data.Entities
{
    public class Unit
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UnitName { get; set; }

        [Required]
        public string BossName { get; set; }

        public DateTime Created { get; set; }

        public List<Order>? Orders { get; set; }
    }
}