using Microsoft.EntityFrameworkCore;
using WeatherAmbassador.Persistence.EF.Models;
using WeatherAmbassador.Services.Constants;

namespace WeatherAmbassador.Persistence.EF
{
    public class WeatherDbContext : DbContext
    {
        public DbSet<Setting> Settings { get; set; }
        public DbSet<WeatherLog> WeatherLogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"...");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Setting>().HasData(
                    new Setting { Id = 1, SettingKey = SettingKey.WeatherApiUrl, SettingValue = "https://webhook.site/17b35eca-2c97-4997-8352-2f0b71e55e83" },
                    new Setting { Id = 2, SettingKey = SettingKey.WeatherApiCallIntervalFormat, SettingValue = "YYYY-MM-dd_HH-mm" }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}