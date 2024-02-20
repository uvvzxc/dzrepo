using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FitCRM.DTOs;
using FitCRM.Models;
using FitCRM.Repository.gymCRUD;

namespace FitCRM.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GymController : ControllerBase
    {
        private readonly IGymCRUD _gymCrud;
        public GymController(IGymCRUD gymRepo)
        {
            _gymCrud = gymRepo;
        }

        [HttpGet]
        public IEnumerable<GYMmodel> GetAll()
        {
            IEnumerable<GYMmodel>? x = _gymCrud.GetAll();
            return x;
        }
        [HttpGet]
        public GYMmodel GetById(int id)
        {
            GYMmodel? x = _gymCrud.GetByID(id);
            return x;
        }
        [HttpPost]
        public string Create(GYMmodelDTO gym)
        {
            string? x = _gymCrud.Create(gym);
            return x;
        }
        [HttpDelete]
        public string Delete(int id)
        {
            string? x = _gymCrud.DeleteByID(id);
            return x;
        }
        [HttpPut]
        public string Update(int id, GYMmodelDTO gym)
        {
            string? x = _gymCrud.Update(id, gym);
            return x;
        }
    }
}
