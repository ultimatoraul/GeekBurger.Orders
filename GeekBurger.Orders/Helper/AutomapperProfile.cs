using AutoMapper;
using GeekBurger.Orders.Contract;
using GeekBurger.Orders.Model;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GeekBurger.Orders.Helper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<OrderToCreate, Order>().AfterMap<MatchStoreFromRepository>();
            CreateMap<Order, OrderToCreate>();
            CreateMap<Order, OrderToGet>();
            CreateMap<EntityEntry<Order>, OrderChangedMessage>()
            .ForMember(dest => dest.Order, opt => opt.MapFrom(src => src.Entity));
            CreateMap<EntityEntry<Order>, OrderChangedEvent>()
            .ForMember(dest => dest.Order, opt => opt.MapFrom(src => src.Entity));
        }
    }
}
