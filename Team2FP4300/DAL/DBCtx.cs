using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team2FP4300.Models;
using System.Data.Entity;

namespace Team2FP4300.DAL
{
    public class DBCtx : DbContext 
    {
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Department> Department { get; set; }
    }
}