using Microsoft.EntityFrameworkCore;

namespace FireAlert.Data;

public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Models.FireAlert> FireAlerts { get; set; }
}