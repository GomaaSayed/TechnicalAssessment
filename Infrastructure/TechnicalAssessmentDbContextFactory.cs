using TechnicalAssessment.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace TechnicalAssessment.Infrastructure
{
    public class TechnicalAssessmentDbContextFactory : IDesignTimeDbContextFactory<TechnicalAssessmentDbContext>
    {
        public TechnicalAssessmentDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var optionsBuilder = new DbContextOptionsBuilder<TechnicalAssessmentDbContext>();
            var connectionString = configuration.GetConnectionString("TechnicalAssessmentConnection");

            optionsBuilder.UseSqlServer(connectionString);

            return new TechnicalAssessmentDbContext(optionsBuilder.Options);
        }
    }
}
