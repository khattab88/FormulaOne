using AutoMapper;
using FormulaOne.API.Dtos.Requests;
using FormulaOne.API.Dtos.Responses;
using FormulaOne.Data.Repositories.Interfaces;
using FormulaOne.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.API.Controllers
{
    public class DriversController : BaseController
    {
        public DriversController(IUnitOfWork unitOfWork, IMapper mapper) 
            : base(unitOfWork, mapper)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDrivers()
        {
            var drivers = await _unitOfWork.Drivers.GetAll();

            if (drivers is null)
                return NotFound();

            var result = _mapper.Map<IEnumerable<DriverResponse>>(drivers);

            return Ok(result);
        }

        [HttpGet]
        [Route("{driverId:Guid}")]
        public async Task<IActionResult> GetDriver(Guid driverId)
        {
            var driver = await _unitOfWork.Drivers.GetById(driverId);

            if(driver is null)
                return NotFound();

            var result = _mapper.Map<DriverResponse>(driver);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddDriver([FromBody] CreateDriverRequest createDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var driver = _mapper.Map<Driver>(createDto);

            await _unitOfWork.Drivers.Add(driver);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction(nameof(GetDriver), new { driverId = driver.Id }, driver);
        }

        [HttpPut]
        public async Task<IActionResult> UpateDriver([FromBody] UpdateDriverRequest updateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var driver = _mapper.Map<Driver>(updateDto);

            await _unitOfWork.Drivers.Update(driver);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        [HttpDelete]
        [Route("{driverId:Guid}")]
        public async Task<IActionResult> DeleteDriver(Guid driverId)
        {
            var driver = await _unitOfWork.Drivers.GetById(driverId);

            if (driver is null)
                return NotFound();

            await _unitOfWork.Drivers.Delete(driverId);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }
    }
}
