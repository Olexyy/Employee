using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public partial class EmployeeDbContext : DbContext
    {
        private static EmployeeDbContext Db { get; set; }
        public EmployeeDbContext(): base("DefaultConnection") { }
    }
}