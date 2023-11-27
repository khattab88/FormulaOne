using AutoMapper;
using FormulaOne.API.Dtos.Requests;
using FormulaOne.API.Dtos.Responses;
using FormulaOne.Data.Repositories.Interfaces;
using FormulaOne.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.API.Controllers
{
    public class AchievementsController : BaseController
    {
        public AchievementsController(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, mapper)
        {
        }

        [HttpGet]
        [Route("{driverId:guid}")]
        public async Task<IActionResult> GetDriverAchievement(Guid driverId)
        {
            var driverAchievement = await _unitOfWork.Achievements.GetDriverAchievementAsync(driverId);

            if (driverAchievement is null)
                return NotFound("Achievement are not found for that driver");

            var result = _mapper.Map<AchievementResponse>(driverAchievement);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddAchievement([FromBody] CreateAchievementRequest createDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var achievement = _mapper.Map<Achievement>(createDto);

            await _unitOfWork.Achievements.Add(achievement);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction(nameof(GetDriverAchievement), new { driverId = achievement.DriverId }, achievement);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAhievement([FromBody] UpdateAchievementRequest updateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var achievement = _mapper.Map<Achievement>(updateDto);

            await _unitOfWork.Achievements.Update(achievement);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }
    }
}
