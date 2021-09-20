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

                //cfg.CreateMap<OnlineUser, OnlineUserModel>().ReverseMap();
                cfg.CreateMap<List<OnlineUser>, List<OnlineUserModel>>().ReverseMap();

                cfg.CreateMap<Book, BookModel>().ReverseMap(); 
                cfg.CreateMap<List<Book>, List<BookModel>>().ReverseMap();

                cfg.CreateMap<Catalogue, CatalogueModel>().ReverseMap();
                cfg.CreateMap<List<Catalogue>, List<CatalogueModel>>().ReverseMap();

                cfg.CreateMap<OnlineUserType, OnlineUserTypeModel>().ReverseMap(); 
                cfg.CreateMap<List<OnlineUserType>, List<OnlineUserTypeModel>>().ReverseMap();

                cfg.CreateMap<Unsubscribe, UnsubscribeModel>().ReverseMap();
                cfg.CreateMap<List<Unsubscribe>, List<UnsubscribeModel>>().ReverseMap();

                cfg.CreateMap<BookCatalogue, BookCatalogueModel>().ReverseMap();
                cfg.CreateMap<List<BookCatalogue>, List<BookCatalogueModel>>().ReverseMap();
            });
            IMapper mapper = config.CreateMapper();
            return mapper;
        }
    }
}
