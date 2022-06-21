using Army.Core.Infrastructure.Enums;

namespace Army.Core.Infrastructure.Models.Entites.Common
{
    public abstract class ResultBase
    {
        public ResultBase()
        {
            Messages = new List<string>();
        }

        public List<string> Messages { get; set; }
        public string Details { get; set; }
        public StatusEnum Status { get; set; }
    }
}
