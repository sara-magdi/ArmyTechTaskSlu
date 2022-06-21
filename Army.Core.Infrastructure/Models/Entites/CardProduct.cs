using Army.Core.Infrastructure.Models.Entites.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Army.Core.Infrastructure.Models.Entites
{
    public class CardProduct :BaseEntity
    {
        public int CardProductId { get; set; }
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public String ItemName { get; set; } = null!;

    }
}
