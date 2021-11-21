using MiniApp1.Core.Repositories;
using MiniApp1.Core.UnitOfWork;
using MiniApp1.Data.Repositories;
using System.Threading.Tasks;

namespace MiniApp1.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;
        private EmployeeRepository _employeeRepository;


        public IEmployeeRepository Employees => _employeeRepository = _employeeRepository ??
            new EmployeeRepository(_appDbContext);

        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public void Commit()
        {
            _appDbContext.SaveChanges();
        }

        public async Task CommmitAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }
    }
}
