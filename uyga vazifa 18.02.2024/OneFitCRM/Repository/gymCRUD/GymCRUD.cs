using Dapper;
using Npgsql;
using FitCRM.Models;
using FitCRM.DTOs;

namespace FitCRM.Repository.gymCRUD
{
    public class GymCRUD : IGymCRUD
    {
        public IConfiguration _config;
        public GymCRUD(IConfiguration config)
        {
            _config = config;
        }

        public string Create(GYMmodelDTO gym)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(_config.GetConnectionString("DefaultConnection")))
                {
                    string query = "insert into gyms(gym_name, gym_location, gym_cost, gym_work_time, gym_rate, gym_sport_type)" +
                        " values(@Gym_name, @Gym_location, @Gym_cost, @Gym_work_time, @Gym_rate, @Gym_sport_type);";
                    var parametres = new GYMmodelDTO
                    {
                        Name = gym.Name,
                        Location = gym.Location,
                        Cost = gym.Cost,
                        Work_time = gym.Work_time,
                        Rate = gym.Rate,
                        Sport_type = gym.Sport_type
                    };
                    connection.Execute(query, parametres);
                }
                return "Ma'lumot qo'shildi!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public IEnumerable<GYMmodel> GetAll()
        {
            try
            {

                using (NpgsqlConnection con = new NpgsqlConnection(_config.GetConnectionString("GymTest")))
                {
                    string query = "select * from gyms;";

                    var responce = con.Query<GYMmodel>(query);

                    return responce;
                }
            }
            catch
            {
                return Enumerable.Empty<GYMmodel>();
            }
        }

        public GYMmodel GetByID(int id)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(_config.GetConnectionString("GymTest")))
                {
                    string query = $"select * from gyms where gym_id = @Gym_id;";

                    var responce = connection.Query<GYMmodel>(query, new {Gym_id = id}).ToList();

                    return responce[0];
                }
            }
            catch (Exception ex)
            {
                return new GYMmodel() { };
            }
        }

        public string DeleteByID(int id)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(_config.GetConnectionString("GymTest")))
                {
                    string query = "delete from gyms where gym_id = @Gym_id;";

                    connection.Execute(query, new {Gym_id = id});

                    return "O'chirildi!";
                }
            }
            catch (Exception ex)
            {
                return "Error!!!";
            }
        }

        public string Update(int id, GYMmodelDTO gym)
        {
            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection(_config.GetConnectionString("GymTest")))
                {
                    string query = "update gyms set gym_name = @gym_name, " +
                        "gym_location = @Gym_location, " +
                        "gym_cost = @Gym_cost, " +
                        "gym_work_time = @Gym_work_time, " +
                        "gym_rate = @Gym_rate, " +
                        "gym_sport_type = @Gym_sport_type;";

                    con.Execute(query, new
                    {
                        gym_name = gym.Name,
                        gym_location = gym.Location,
                        gym_cost = gym.Cost,
                        gym_work_time = gym.Work_time,
                        gym_rate = gym.Rate,
                        gym_sport_type = gym.Sport_type
                    });

                    return "Yangilandi!";
                }
            }
            catch (Exception ex)
            {
                return "Error!!!";
            }
        }
    }
}
