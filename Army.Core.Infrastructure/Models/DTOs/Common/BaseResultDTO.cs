

using Army.Core.Infrastructure.Enums;

namespace Army.Core.Infrastructure.Models.DTOs.Common

{
    public class BaseResultDTO
    {
        public BaseResultDTO()
        {
            Messages = new List<string>();
        }
        public List<string> Messages { get; set; }
        public string Details { get; set; } = null!;
        public StatusEnum Status { get; set; }

    }
}
