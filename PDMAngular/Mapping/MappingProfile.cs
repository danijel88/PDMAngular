using AutoMapper;
using PDMAngular.Controllers.Resources;
using PDMAngular.Models;

namespace PDMAngular.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain to API Resource
            CreateMap<ItemType, ItemTypeResource>();
            CreateMap<MachineType, MachineTypeResource>();
            CreateMap<Item, ItemResource>();


            //API Resource to Domain
            CreateMap<ItemResource, Item>()
                .ForMember(i => i.Id, opt => opt.Ignore());
            CreateMap<ItemTypeResource, ItemType>();
            CreateMap<MachineTypeResource, MachineType>();

        }
    }
}
