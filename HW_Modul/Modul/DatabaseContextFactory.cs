using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul
{
    public class DatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {     
        public DatabaseContext CreateDbContext(string[] args)
        {
            const string connStr = "Server=(localdb)\\MSSQLLocalDB;Database=Modul4;Trusted_Connection=True;MultipleActiveResultSets=true";
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            var options = optionsBuilder.UseSqlServer(connStr).Options;
            return new DatabaseContext(options);
        }
    }
}
