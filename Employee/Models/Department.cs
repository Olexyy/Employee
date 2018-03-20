using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication.Models
{
    [Serializable]
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Index]
        [Required]
        [StringLength(150)]
        public string Name { get; set; }
    }
    public partial class EmployeeDbContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
    }
}