using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineBooks.DataAccess.Contracts;
using OnlineBooks.DataAccess.DTO;
using OnlineBooks.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBooks.DataAccess.Implementations
{
   public class CatalogueDataAccess: ICatalogueDataAccess
    {
        private readonly OnlineBooksContext _onlineBooksContext;
        private readonly IMapper _mapper;

        public CatalogueDataAccess(OnlineBooksContext onlineBooksContext)
        {
            _onlineBooksContext = onlineBooksContext;
            _mapper = Mappings.MappingProfile.MapperConfiguration();
        }

        public async Task<bool> CreateCatalogue(CatalogueModel request)
        {
            var catalogueDto = _mapper.Map<CatalogueModel, Catalogue>(request);
            _onlineBooksContext.Catalogues.Add(catalogueDto);
            var response = _onlineBooksContext.SaveChanges();
            if (response == 1)
                return true;

            return false;
        }

        public async Task<bool> DeleteCatalogue(Guid catalogueId)
        {
            Catalogue catalogueDto = _onlineBooksContext.Catalogues.FirstOrDefault(x => x.CatalogueId == catalogueId);
            if (catalogueDto is null)
                return false;
            catalogueDto.IsDeleted = true;
            var response = _onlineBooksContext.SaveChanges();
            if (response == 1)
                return true;

            return false;
        }

        public async Task<IEnumerable<CatalogueModel>> GetCatalogues()
        {
            var catalogues = new List<CatalogueModel>();
            var cataloguesDto = _onlineBooksContext.Catalogues.Include(x => x.BookCatalogues).Where(x=> x.IsDeleted == false).ToList();
            for (int i = 0; i < cataloguesDto.Count; i++)
            {
                var catalogue = _mapper.Map<Catalogue, CatalogueModel>(cataloguesDto[i]);
                catalogues.Add(catalogue);
            }
            return catalogues;
        }

        public async Task<bool> UpdateCatalogue(CatalogueModel request)
        {
            Catalogue bookDto = _onlineBooksContext.Catalogues.FirstOrDefault(x => x.CatalogueId == request.CatalogueId);
            _mapper.Map<CatalogueModel, Catalogue>(request, bookDto);
            var response = _onlineBooksContext.SaveChanges();
            if (response == 1)
                return true;

            return false;
        }
    }
}
