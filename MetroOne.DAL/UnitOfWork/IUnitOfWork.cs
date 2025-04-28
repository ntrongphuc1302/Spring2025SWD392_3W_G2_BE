using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroOne.DAL.Repositories.Interfaces;

namespace MetroOne.DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        ITrainRepository Trains { get; }
        IStationRepository Stations { get; }
        ITicketRepository Tickets { get; }
        ITripRepository Trips { get; }
        ILocationRepository Locations { get; }
        IRouteRepository Routes { get; }
        IRouteLocationRepository RouteLocations { get; }

        IPaymentRepository Payments { get; }

        Task<int> SaveAsync();
    }

}
