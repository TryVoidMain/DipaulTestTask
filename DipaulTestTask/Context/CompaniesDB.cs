using DipaulTestTask.Models;
using Microsoft.EntityFrameworkCore;

namespace DipaulTestTask.Context
{
    public class CompaniesDB : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Company> Companies { get; set; }
        public CompaniesDB(DbContextOptions<CompaniesDB> opt):base(opt) { }
    }
}
