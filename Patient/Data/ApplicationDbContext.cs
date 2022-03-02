using Microsoft.EntityFrameworkCore;
using Patient.Models;


namespace Patient.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Doctors> DoctorNames { get; set; }
        public DbSet<PatientDetails> PatientDetailss { get; set; }
        public DbSet<Status> Statuses { get; set; }

    }
}
