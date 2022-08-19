using AutoMapper;
using OnlineBooks.DataAccess.DTO;
using OnlineBooks.Model;
using System.Collections.Generic;

namespace OnlineBooks.DataAccess.Mappings
{
    public static class MappingProfile
    {
        public static IMapper MapperConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<OnlineUser, OnlineUserModel>()
                .ForMember(dest => dest.UserType, src => src.MapFrom(o => o.OnlineUserType)).ReverseMap();

                cfg.CreateMap<OnlineUser, OnlineUserModel>()
                .ForMember(dest => dest.Subscriptions, src => src.MapFrom(o => o.Subscriptions)).ReverseMap();

                cfg.CreateMap<List<OnlineUser>, List<OnlineUserModel>>().ReverseMap();

                cfg.CreateMap<Book, BookModel>().ReverseMap(); 
                cfg.CreateMap<List<Book>, List<BookModel>>().ReverseMap();

                cfg.CreateMap<Catalogue, CatalogueModel>()
                .ForMember(dest => dest.BookCatalogues, src => src.MapFrom(o => o.BookCatalogues)).ReverseMap();

                cfg.CreateMap<List<Catalogue>, List<CatalogueModel>>().ReverseMap();

                cfg.CreateMap<OnlineUserType, OnlineUserTypeModel>().ReverseMap(); 
                cfg.CreateMap<List<OnlineUserType>, List<OnlineUserTypeModel>>().ReverseMap();

                cfg.CreateMap<Subscription, SubscriptionModel>().ReverseMap();
                cfg.CreateMap<List<Subscription>, List<SubscriptionModel>>().ReverseMap();

                cfg.CreateMap<Unsubscribe, UnsubscribeModel>().ReverseMap();
                cfg.CreateMap<List<Unsubscribe>, List<UnsubscribeModel>>().ReverseMap();

                cfg.CreateMap<BookCatalogue, BookCatalogueModel>()
               .ForMember(dest => dest.Book, src => src.MapFrom(o => o.Book)).ReverseMap();
                cfg.CreateMap<List<BookCatalogue>, List<BookCatalogueModel>>().ReverseMap();
            });
            IMapper mapper = config.CreateMapper();
            return mapper;
        }
    }
}
