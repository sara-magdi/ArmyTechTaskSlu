using Army.Core.Infrastructure.Models.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Army.Core.Infrastructure.Models.DTOs
{
    public class CardProductDTO :BaseDTO
    {
        public int CardProductId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public String ItemName { get; set; } = null!;
    }
}
