using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LionLoansApi.DAL
{
    public class LionLoansSQLDAL : DbContext
    {
        public LionLoansSQLDAL(DbContextOptions<LionLoansSQLDAL> options) : base(options) { }
        public DbSet<LionLoansSQLEntity> FirstEntities { get; set; }
    }
}
