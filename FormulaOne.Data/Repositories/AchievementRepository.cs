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
    public class AchievementRepository : GenericRepository<Achievement>, IAchievementRepository
    {
        public AchievementRepository(ILogger logger, AppDbContext context) : base(logger, context)
        {
        }

        public async Task<Achievement?> GetDriverAchievementAsync(Guid driverId)
        {
            try
            {
                return await _dbSet.FirstOrDefaultAsync(a => a.DriverId == driverId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo}: Error in GetDriverAchievementAsync()", typeof(AchievementRepository));
                throw;
            }
        }

        public override async Task<IEnumerable<Achievement>> GetAll()
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
                _logger.LogError(ex, "{Repo}: Error in GetAll()", typeof(AchievementRepository));
                throw;
            }
        }

        public override async Task<bool> Delete(Guid id)
        {
            try
            {
                var achievement = await _dbSet.FirstOrDefaultAsync(d => d.Id == id);

                if (achievement is null)
                    return false;

                achievement.Status = 0;
                achievement.UpdatedAt = DateTime.UtcNow;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo}: Error in Delete()", typeof(AchievementRepository));
                throw;
            }
        }

        public override async Task<bool> Update(Achievement entity)
        {
            try
            {
                var achievement = await _dbSet.FirstOrDefaultAsync(d => d.Id == entity.Id);

                if (achievement is null)
                    return false;

                achievement.UpdatedAt = DateTime.UtcNow;
                achievement.FastestLap = entity.FastestLap;
                achievement.PolePosition = entity.PolePosition;
                achievement.RaceWins = entity.RaceWins;
                achievement.WorldChampionship = entity.WorldChampionship;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo}: Error in Update()", typeof(AchievementRepository));
                throw;
            }
        }
    }
}
