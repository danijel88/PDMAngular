using AutoMapper;
using PDMAngular.Controllers.Resources;
using PDMAngular.Models;

namespace PDMAngular.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ItemType, ItemTypeResource>();
            CreateMap<MachineType, MachineTypeResource>();
        }
    }
}
