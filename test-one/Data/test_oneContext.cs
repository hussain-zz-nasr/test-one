using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using test_one.Model;

namespace test_one.Data
{
    public class test_oneContext : DbContext
    {
        public test_oneContext (DbContextOptions<test_oneContext> options)
            : base(options)
        {
        }

        public DbSet<test_one.Model.Customer> Customer { get; set; } = default!;
    }
}
