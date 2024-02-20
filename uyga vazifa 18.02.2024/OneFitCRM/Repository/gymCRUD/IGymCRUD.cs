using FitCRM.Models;
using FitCRM.DTOs;

namespace FitCRM.Repository.gymCRUD
{
    public interface IGymCRUD
    {
        public string Create(GYMmodelDTO gym);
        public IEnumerable<GYMmodel> GetAll();
        public GYMmodel GetByID(int id);
        public string DeleteByID(int id);
        public string Update(int id, GYMmodelDTO gym);
    }
}
