using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FitCRM.DTOs;
using FitCRM.Models;
using FitCRM.MyServices.IServices;

namespace FitCRM.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GymController : ControllerBase
    {
        private readonly IGymService _gymService;
        public GymController(IGymService gymRepo)
        {
            _gymService = gymRepo;
        }

        [HttpGet]
        public IEnumerable<GYMmodel> GetAll()
        {
            IEnumerable<GYMmodel>? x = _gymService.GetAll();
            return x;
        }
        [HttpGet]
        public GYMmodel GetById(int id)
        {
            GYMmodel? x = _gymService.GetByID(id);
            return x;
        }
        [HttpPost]
        public string Create(GYMmodelDTO gym)
        {
            string? x = _gymService.Create(gym);
            return x;
        }
        [HttpDelete]
        public string Delete(int id)
        {
            string? x = _gymService.DeleteByID(id);
            return x;
        }
        [HttpPut]
        public string Update(int id, GYMmodelDTO gym)
        {
            string? x = _gymService.Update(id, gym);
            return x;
        }
    }
}
