using OnlineBooks.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineBooks.DataAccess.Contracts
{
    public interface ICatalogueDataAccess
    {
        Task<IEnumerable<CatalogueModel>> GetCatalogues();
        Task<bool> CreateCatalogue(CatalogueModel request);
        Task<bool> UpdateCatalogue(CatalogueModel request);
        Task<bool> DeleteCatalogue(Guid catalogueId);
    }
}
 