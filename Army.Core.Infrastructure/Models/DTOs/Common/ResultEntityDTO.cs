namespace Army.Core.Infrastructure.Models.DTOs.Common
{
    public class ResultEntityDTO<T> : BaseResultDTO
    {
        public T Entity { get; set; }

    }
}
