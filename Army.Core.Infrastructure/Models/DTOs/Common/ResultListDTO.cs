namespace Army.Core.Infrastructure.Models.DTOs.Common
{
    public class ResultListDTO<T> : BaseResultDTO
    {
        public ResultListDTO()
        {
            Items = new List<T>();
        }

        public List<T> Items { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int Count { get; set; }
    }
}
