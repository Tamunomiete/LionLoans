using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LionLoansApi.DAL
{
    public class SQLDAL:DbContext
    {
        public SQLDAL(DbContextOptions<SQLDAL> options) : base(options) { }

        public DbSet<UserRequest> Users { get; set; }

    }
}
