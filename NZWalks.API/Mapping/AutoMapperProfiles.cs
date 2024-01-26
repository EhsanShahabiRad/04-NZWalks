using AutoMapper;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Mapping
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles() {
            CreateMap<Region, RegionDTO>().ReverseMap();
            CreateMap<Region, AddRegionDTO>().ReverseMap();
            CreateMap<Region, UpdateRegionDTO>().ReverseMap();
            CreateMap<Walk,WalkDTO>().ReverseMap();
            CreateMap<AddWalkDTO,Walk>().ReverseMap();
            CreateMap<UpdateWalkDTO,Walk>().ReverseMap();

        }
    }
}
