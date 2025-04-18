using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroOne.DAL.Repositories.Interfaces;

namespace MetroOne.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MetroonedbContext _context;

        public IUserRepository Users { get; }

        public UnitOfWork(
            MetroonedbContext context,
            IUserRepository userRepository)
        {
            _context = context;
            Users = userRepository;
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
