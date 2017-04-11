using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WebApplication1.Models;


namespace WebApplication1.DAL
{   
        public class DatabaseCTX : DbContext
        {
            public DbSet<Employee> Employees { get; set; }

        }
}
   