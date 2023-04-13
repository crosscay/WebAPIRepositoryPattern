using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebAPIRepositoryPattern.Models;
using WebAPIRepositoryPattern.Paging;

namespace WebAPIRepositoryPattern.Repository
{
    public class EmployeeRepository: RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDBContext applicationDBContext):base(applicationDBContext)
        {

        }

        public async Task CreateEmployee(Employee employee)
        {
            //throw new NotImplementedException();
            await AddAsync(employee);
        }

        public async Task DeleteEmployee(Employee employee, int id)
        {
            // throw new NotImplementedException();
            await DeleteAsync(employee, id);
        }

        public async Task<Employee> GetEmployee(int id)
        {
            var query = FindbyCondition(e => e.EmpId == id);

            Employee? resp = await query.FirstOrDefaultAsync();

            //Employee? resp = await query.Select(u => new Employee
            //{
            //    EmpId = u.EmpId,
            //    EmpName = u.EmpName,
            //    Designation = u.Designation,
            //    Department = u.Department,
            //    JoinDate = u.JoinDate
            //}).FirstOrDefaultAsync();

            if (resp != null)
            {
                return resp;
            }

            return new Employee();
        }

        public async Task<Employee> FindEmployee(int id)
        {
            List<Employee> query = await GetWhereAsync(e => e.EmpId == id);
            Employee? resultado = query.FirstOrDefault();

            return resultado;
            // Employee? resp = await query.FirstOrDefaultAsync();
            // if (resp != null)
            // {
            //    return resp;
            // }
        }

        public Task<PagedList<Employee>> GetEmployees(PagingParameters pagingParameters)
        {
            //throw new NotImplementedException();
            return Task.FromResult(PagedList<Employee>.GetPagedList(FindAll().OrderBy(s=> s.EmpId), pagingParameters.PageNumber, pagingParameters.PageSize));
        }

        public async Task UpdateEmployee(Employee employee, int id)
        {
            //throw new NotImplementedException();
            await UpdateAsync(employee, id);
        }
    }
}
