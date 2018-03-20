using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebApplication.Models
{
    [Serializable]
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Index]
        [Required]
        [StringLength(150)]
        public string Name { get; set; }
        public bool Active { get; set; }
        public int? DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
    public partial class EmployeeDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
    }
}