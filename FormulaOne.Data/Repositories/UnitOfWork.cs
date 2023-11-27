using FormulaOne.Data.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDbContext _context;

        public IDriverRepository Drivers { get; }

        public IAchievementRepository Achievements { get; }

        public UnitOfWork(AppDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;

            var logger = loggerFactory.CreateLogger("Logs");

            Drivers = new DriverRepository(logger, context);
            Achievements = new AchievementRepository(logger, context);
        }

        public async Task<bool> CompleteAsync()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
