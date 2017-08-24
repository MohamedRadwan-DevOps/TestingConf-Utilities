using System;
using System.Data.Entity;

namespace Codeflyers.EC.Domain.Concrete
{
    public class EfDbContext : DbContext
    {
        public EfDbContext(string connectionString):base(connectionString)
        {
        }


    }
}
