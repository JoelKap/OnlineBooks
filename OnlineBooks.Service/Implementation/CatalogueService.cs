using OnlineBooks.DataAccess.Contracts;
using OnlineBooks.Model;
using OnlineBooks.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBooks.Service.Implementation
{
   public class CatalogueService: ICatalogueService
    {
        private ICatalogueDataAccess _catalogueDataService;
        public CatalogueService(ICatalogueDataAccess catalogueDataService)
        {
            _catalogueDataService = catalogueDataService;
        }

        public async Task<bool> CreateCatalogue(CatalogueModel request)
        {
            return await _catalogueDataService.CreateCatalogue(request);
        }

        public async Task<bool> DeleteCatalogue(Guid catalogueId)
        {
            return await _catalogueDataService.DeleteCatalogue(catalogueId);
        }

        public async Task<IEnumerable<CatalogueModel>> GetCatalogues()
        {
            return await _catalogueDataService.GetCatalogues();
        }

        public async Task<bool> UpdateCatalogue(CatalogueModel request)
        {
            return await _catalogueDataService.UpdateCatalogue(request);
        }
    }
}
