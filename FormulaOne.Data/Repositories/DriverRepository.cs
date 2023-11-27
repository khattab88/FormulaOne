using FormulaOne.Data.Repositories.Interfaces;
using FormulaOne.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.Data.Repositories
{
    public class DriverRepository : GenericRepository<Driver>, IDriverRepository
    {
        public DriverRepository(ILogger logger, AppDbContext context) : base(logger, context)
        {
        }

        public override async Task<IEnumerable<Driver>> GetAll()
        {
            try
            {
                return await _dbSet.Where(d => d.Status == 1)
                    .AsNoTracking()
                    .AsSplitQuery()
                    .OrderBy(d => d.CreatedAt)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo}: Error in GetAll()", typeof(DriverRepository));
                throw;
            }
        }

        public override async Task<bool> Delete(Guid id)
        {
            try
            {
                var driver = await _dbSet.FirstOrDefaultAsync(d => d.Id == id);

                if (driver is null) 
                    return false;

                driver.Status = 0;
                driver.UpdatedAt = DateTime.UtcNow;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo}: Error in Delete()", typeof(DriverRepository));
                throw;
            }
        }

        public override async Task<bool> Update(Driver entity)
        {
            try
            {
                var driver = await _dbSet.FirstOrDefaultAsync(d => d.Id == entity.Id);

                if (driver is null)
                    return false;

                driver.UpdatedAt = DateTime.UtcNow;
                driver.FirstName = entity.FirstName;
                driver.LastName = entity.LastName;
                driver.DateOfBirth = entity.DateOfBirth;
                driver.DriverNumber = entity.DriverNumber;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo}: Error in Update()", typeof(DriverRepository));
                throw;
            }
        }
    }
}
