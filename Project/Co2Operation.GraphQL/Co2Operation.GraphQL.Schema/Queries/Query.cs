using System.Collections.Generic;
using System.Threading.Tasks;
using Co2Operation.GraphQL.DataAccess.Models;
using Co2Operation.GraphQL.DataAccess.Repositories.Interfaces;
using HotChocolate;

namespace Co2Operation.GraphQL.Schema.Queries
{
    public class Query
    {
        #region CarQueries
        public async Task<IList<Car>> GetCars([Service] ICarRepository repository) => 
            await repository.GetAll();

        public async Task<Car> GetCarById([Service] ICarRepository repository, int id) =>
            await repository.Get(id);
        public async Task<IList<Car>> GetCarsByUserId([Service] ICarRepository repository, int userId) =>
            await repository.GetListByUserId(userId);

        #endregion

        #region UserQueries
        public async Task<IList<User>> GetUsers([Service] IUserRepository repository) => 
            await repository.GetAll();
        public async Task<User> GetUserById([Service] IUserRepository repository, int id) => 
            await repository.Get(id);

        #endregion

        #region TripQueries
        
        public async Task<IList<Trip>> GetTrips([Service] ITripRepository repository) => 
            await repository.GetAll();
        
        public async Task<Trip> GetTripById([Service] ITripRepository repository, int id) => 
            await repository.Get(id);
        
        public async Task<IList<Trip>> GetTripsByUserId([Service] ITripRepository repository, int id) => 
            await repository.GetListByUserId(id);


        #endregion

        #region CarbonHistoryQueries
        public async Task<IList<CarbonHistroy>> GetCarbonHistories([Service] ICarbonHistoryRepository repository) => 
            await repository.GetAll();
        public async Task<IList<CarbonHistroy>> GetCarbonHistoriesByUserId([Service] ICarbonHistoryRepository repository, int userId) =>
            await repository.GetListByUserId(userId);

        #endregion

        #region TransportMethodQueries
        public async Task<IList<TransportMethods>> GetTransportMethods([Service] ITransportMethodsRepository repository) => 
            await repository.GetAll();
        public async Task<TransportMethods> GetTransportMethodById([Service] ITransportMethodsRepository repository, int id) => 
            await repository.Get(id);
        

        #endregion
        
    }
}