using AutoMapper;
using PDMAngular.Controllers.Resources;
using PDMAngular.Core.Models;

namespace PDMAngular.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Resource to Resource
            CreateMap<SaveItemResource, SaveItemHistResource>();

            //Domain to API Resource
            CreateMap<Photo, PhotoResource>();
            CreateMap<ItemType, KeyValuePairResource>();
            CreateMap<MachineType, MachineTypeResource>();
            CreateMap<Item, SaveItemResource>();
            CreateMap<ItemHist, SaveItemResource>();
            CreateMap<Item, ItemResource>()
                .ForMember(ir => ir.MachineType, opt => opt.MapFrom(i => new MachineTypeResource { Id = i.MachineType.Id, Name = i.MachineType.Name }))
                .ForMember(ir => ir.ItemType, opt => opt.MapFrom(i => new KeyValuePairResource { Id = i.ItemType.Id, Name = i.ItemType.Name }));


            //API Resource to Domain
            CreateMap<ItemQueryResource, ItemQuery>();
            CreateMap<SaveItemResource, Item>()
                .ForMember(i => i.Id, opt => opt.Ignore());
            CreateMap<KeyValuePairResource, ItemType>();
            CreateMap<MachineTypeResource, MachineType>();
            CreateMap<SaveItemResource, ItemHist>();
            CreateMap<ItemResource, Item>();
            CreateMap<SaveItemHistResource, ItemHist>();


        }
    }
}
