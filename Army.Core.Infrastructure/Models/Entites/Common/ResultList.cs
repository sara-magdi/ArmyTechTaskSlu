namespace Army.Core.Infrastructure.Models.Entites.Common
{
    public class ResultList<T> : ResultBase
    {
        public ResultList()
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
