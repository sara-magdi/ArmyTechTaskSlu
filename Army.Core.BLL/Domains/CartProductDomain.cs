using Army.Core.BLL.Domains;
using Army.Core.Infrastructure.Models.DTOs;
using Army.Core.Infrastructure.Models.Entites;
using Army.Core.Infrastructure.Models.Entites.Common;
using AutoMapper;
using Meshini.Core.DAL.Repositories;


namespace Meshini.Core.BLL.Domains
{
    public class CardProductDomain : BaseDomain<CardProductRepository, CardProduct, CardProductDTO>
    {
        public CardProductDomain(IMapper mapper, CardProductRepository repository)
            : base(mapper, repository)
        {
        }


    }
}
