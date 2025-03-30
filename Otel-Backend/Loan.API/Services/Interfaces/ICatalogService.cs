using Models;

namespace Loan.API.Services.Interfaces
{
    public interface ICatalogService
    {
        Task<Product> GetProduct(int ProductIdId);
         Task<Boolean> GetScoring(LoanApplication loan);
    }
}