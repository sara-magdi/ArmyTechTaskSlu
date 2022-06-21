namespace Army.Core.Infrastructure.Models.Entites.Common
{
    public class ResultEntity<T> : ResultBase
    {
        public T Entity { get; set; }

        public static implicit operator ResultEntity<T>(Task<ResultEntity<int>> v)
        {
            throw new NotImplementedException();
        }
    }
}
