using LionLoansApi.DAL;

namespace LionLoansApi.Interface
{
    public interface IDatabaseService
    {
        Task<List<LionLoansSQLEntity>> GetFirstEntitiesAsync();
    }
}
