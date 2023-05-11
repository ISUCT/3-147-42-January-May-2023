using application.Models;
using application.Models.Answers;
using Microsoft.EntityFrameworkCore;

namespace application.Additionals;

public class DatabaseContext : DbContext
{
    public DbSet<Survey> Surveys { get; set; } = null!;
    
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql("server=MySQLContainer;port=5050;database=survey_db;user=root;password=root;",
            new MySqlServerVersion(new Version(8, 0, 32)));
    }
}
