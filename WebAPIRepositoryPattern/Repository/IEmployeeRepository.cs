using WebAPIRepositoryPattern.Models;
using WebAPIRepositoryPattern.Paging;

namespace WebAPIRepositoryPattern.Repository
{
    public interface IEmployeeRepository:IRepositoryBase<Employee>
    {
        Task<PagedList<Employee>> GetEmployees(PagingParameters pagingParameter);
        Task<Employee> GetEmployee(int id);
        Task<Employee> FindEmployee(int id);
        Task CreateEmployee(Employee employee);
        Task UpdateEmployee(Employee employee, int id);
        Task DeleteEmployee(Employee employee, int id);
    }
}
