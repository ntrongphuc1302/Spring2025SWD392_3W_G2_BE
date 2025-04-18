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
        ITrainRepository TrainRepository { get; }

        Task<int> SaveAsync();
    }

}
