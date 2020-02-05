using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Route.Api.Data;
using Route.Api.Enties;

namespace Route.Api.Services
{
    public class CompanyReponsitory : IComanyRepository
    {
        private readonly RouteDbContext _context;
        public CompanyReponsitory(RouteDbContext context)
        {

            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        /// <summary>
        /// 添加公司
        /// </summary>
        /// <param name="company"></param>
        public void AddCompany(Company company)
        {
            if (company == null)
            {
                throw new ArgumentNullException(nameof(company));
            }
            company.Id = Guid.NewGuid();
            foreach (var employee in company.Employees)
            {
                employee.Id = Guid.NewGuid();
            }
            _context.Companies.Add(company);
        }
        /// <summary>
        /// 添加员工
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="employee"></param>
        public void AddEmployee(Guid companyId, Employee employee)
        {
            if (companyId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(companyId));
            }
            if (employee ==null)
            {
                throw new ArgumentNullException(nameof(employee));
            }
            employee.CompanyId = companyId;
            _context.Employees.Add(employee);
        }
        /// <summary>
        /// 根据id判断公司是否存在
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public async Task<bool> CompanyExistsAsync(Guid companyId)
        {
            if (companyId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(companyId));
            }
            return await _context.Companies.AnyAsync(x => x.Id == companyId);
        }
        /// <summary>
        /// 删除公司
        /// </summary>
        /// <param name="company"></param>
        public void DeleteCompany(Company company)
        {
            if (company == null)
            {
                throw new ArgumentNullException(nameof(company));
            }
            _context.Companies.Remove(company);
        }
        /// <summary>
        /// 删除员工
        /// </summary>
        /// <param name="employee"></param>
        public void DeleteEmployee(Employee employee)
        {

            if (employee == null)
            {
                throw new ArgumentNullException(nameof(employee));
            }
            _context.Employees.Remove(employee);
        }
        /// <summary>
        /// 返回公司集合
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Company>> GetCompaniesAsync()
        {
            return await _context.Companies.ToListAsync();
        }
        /// <summary>
        /// 根据id集合获取公司集合
        /// </summary>
        /// <param name="companyIds"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Company>> GetCompaniesAsync(IEnumerable<Guid> companyIds)
        {
            if (companyIds == null)
            {
                throw new ArgumentNullException(nameof(companyIds));
            }
            return await _context.Companies
                .Where(x => companyIds.Contains(x.Id))
                .OrderBy(x => x.Name)
                .ToListAsync();


        }
        /// <summary>
        /// 根据id获取公司
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public async Task<Company> GetCompanyAsync(Guid companyId)
        {
            if (companyId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(companyId));
            }
            return await _context.Companies
                .FirstOrDefaultAsync(x => x.Id == companyId);
        }
        /// <summary>
        /// 获取某公司下的某一个员工
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public async Task<Employee> GetEmployeeAsync(Guid companyId, Guid employeeId)
        {
            if (companyId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(companyId));
            }
            if (employeeId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(employeeId));
            }
            return await _context.Employees
                .Where(x => x.CompanyId == companyId && x.Id == employeeId)
                .FirstOrDefaultAsync();

        }
        /// <summary>
        /// 获取员工
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Employee>> GetEmployeesAsync(Guid companyId)
        {
            if (companyId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(companyId));
            }
            return await _context.Employees
                .Where(x => x.CompanyId == companyId)
                .OrderBy(x => x.EmployeeNo)
                .ToListAsync();
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void UpdateCompany(Company company)
        {

        }

        public void UpdateEmployee(Employee employee)
        {
            //_context.Entry(employee).State = EntityState.Modified ;
        }
    }
}
