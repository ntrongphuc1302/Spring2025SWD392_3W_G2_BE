using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroOne.DAL.Repositories.Implementations;
using MetroOne.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication;

namespace MetroOne.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MetroonedbContext _context;

        public IUserRepository Users { get; }
        public ILocationRepository Locations { get; private set; }
        public ITrainRepository Trains { get; private set; }
        public IStationRepository Stations { get; private set; }
        public ITicketRepository Tickets { get; private set; }
        public ITripRepository Trips { get; private set; }
        public IPaymentStatusRepository PaymentStatuses { get; private set; }

        public UnitOfWork(
            MetroonedbContext context,
            IUserRepository userRepository)
        {
            _context = context;
            Users = userRepository;
            Trains = new TrainRepository(context);
            Stations = new StationRepository(context);
            Tickets = new TicketRepository(context);
            Trips = new TripRepository(context);
            Locations = new LocationRepository(context);
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }


        public void Dispose()
        {
            _context.Dispose();
        }
    }

}
