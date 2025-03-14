using LionLoansApi.Interface;
using Microsoft.EntityFrameworkCore;

namespace LionLoansApi.DAL
{
    public class DatabaseService :IDatabaseService
    {

        private readonly LionLoansSQLDAL _lionloanssqldal;
        public DatabaseService(LionLoansSQLDAL firstDbContext)
        {
            _lionloanssqldal = firstDbContext;

        }
      

        public async Task<List<LionLoansSQLEntity>> GetFirstEntitiesAsync()
        {
            return await _lionloanssqldal.FirstEntities.ToListAsync();
        }
    }
}
