using Microsoft.EntityFrameworkCore;

namespace StudentsManager.Models
{
    public class StudenciDbContext : DbContext
    {
        public StudenciDbContext()
        {

        }

        public DbSet<Students> Studenci { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=db-mssql.pjwstk.edu.pl;Initial Catalog=pd4036;Integrated Security=True; TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }


    }
}
