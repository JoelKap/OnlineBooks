using OnlineBooks.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineBooks.Service.Contracts
{
    public  interface ICatalogueService
    {
        Task<IEnumerable<CatalogueModel>> GetCatalogue();
        Task<bool> CreateCatalogue(CatalogueModel request);
        Task<bool> UpdateCatalogue(CatalogueModel request);
        Task<bool> DeleteCatalogue(Guid catalogueId);
    }
}
 