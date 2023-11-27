using AutoMapper;
using FormulaOne.Data.Repositories.Interfaces;

namespace FormulaOne.API.Controllers
{
    public class DriversController : BaseController
    {
        public DriversController(IUnitOfWork unitOfWork, IMapper mapper) 
            : base(unitOfWork, mapper)
        {
        }
    }
}
