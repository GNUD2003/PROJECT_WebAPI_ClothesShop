using Project_Data.Data;
using Project_Data.Repository;
using Project_Model.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Data.Infra
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly AppDBContext _context;

       // private IGenericRepository<Appointment> _appointmentRepository;
        private IUserRepository _userRepository;

        public UnitOfWork(AppDBContext dbContext)
        {
            _context = dbContext;
        }

        public AppDBContext Context => _context;

        public IUserRepository UserRepository => _userRepository ?? new UserRepository(_context);

      //  public IGenericRepository<Appointment> AppointmentRepository => _appointmentRepository ?? new Repository<Appointment>(_context);



        public async Task BeginTransactionAsync()
        {
            await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            await _context.Database.CommitTransactionAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IBaseRepositoty<T> GenericRepository<T>() where T : class
        {
            return new BaseRepository<T>(_context);
        }


        public async Task RollbackTransactionAsync()
        {
            await _context.Database.RollbackTransactionAsync();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}

