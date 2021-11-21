using Microsoft.EntityFrameworkCore;
using MiniApp1.Core.Models;
using MiniApp1.Core.Repositories;
using System.Threading.Tasks;


namespace MiniApp1.Data.Repositories
{
    class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        private AppDbContext _appDbContext { get=> _context as AppDbContext; }

        public EmployeeRepository(AppDbContext context) : base(context)
        {

        }
        public async Task<Employee> GetEmployeeByUserId(string userId)
        {
            return await _appDbContext.Employees.FirstOrDefaultAsync(x=>x.UserId == userId);
        }
    }
}
