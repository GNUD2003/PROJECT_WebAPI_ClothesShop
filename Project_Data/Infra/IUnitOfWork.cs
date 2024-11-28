using Project_Data.Data;
using Project_Model.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Data.Infra
{
    public interface IUnitOfWork : IDisposable
    {
        AppDBContext Context { get; }
        IUserRepository UserRepository { get; }
        //    IGenericRepository<Appointment> AppointmentRepository { get; }
        IBaseRepositoty<T> GenericRepository<T>() where T : class;

        int SaveChanges();
        Task<int> SaveChangesAsync();
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}