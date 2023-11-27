using AutoMapper;
using FormulaOne.Data.Repositories.Interfaces;

namespace FormulaOne.API.Controllers
{
    public class AchievementsController : BaseController
    {
        public AchievementsController(IUnitOfWork unitOfWork, IMapper mapper) 
            : base(unitOfWork, mapper)
        {
        }
    }
}
