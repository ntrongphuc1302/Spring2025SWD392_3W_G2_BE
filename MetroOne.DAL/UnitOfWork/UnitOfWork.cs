using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroOne.DAL.Repositories.Implementations;
using MetroOne.DAL.Repositories.Interfaces;

namespace MetroOne.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MetroonedbContext _context;

        public IUserRepository Users { get; }

        public ITrainRepository TrainRepository { get; private set; }

        public UnitOfWork(
            MetroonedbContext context,
            IUserRepository userRepository)
        {
            _context = context;
            Users = userRepository;
            TrainRepository = new TrainRepository(context);
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
