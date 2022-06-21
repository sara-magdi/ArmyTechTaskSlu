using Army.Core.Infrastructure.Models.DTOs;
using Army.Core.Infrastructure.Models.Entites;
using Army.Core.Infrastructure.Models.Entites.Common;
using AutoMapper;

namespace ArmyTechTask
{
    public partial class MappingProfile : Profile
    {
        public MappingProfile()
        {


            CreateMap<CardProduct, CardProductDTO>().MaxDepth(3).PreserveReferences().ReverseMap();


            CreateMap(typeof(ResultList<>), typeof(ResultList<>));
            CreateMap(typeof(ResultEntity<>), typeof(ResultEntity<>));

        }
    }
}
