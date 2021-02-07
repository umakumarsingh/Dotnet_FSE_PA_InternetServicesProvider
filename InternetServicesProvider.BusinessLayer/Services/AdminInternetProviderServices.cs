using InternetServicesProvider.BusinessLayer.Interfaces;
using InternetServicesProvider.BusinessLayer.Services.Repository;
using InternetServicesProvider.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InternetServicesProvider.BusinessLayer.Services
{
    public class AdminInternetProviderServices : IAdminInternetProviderServices
    {
        /// <summary>
        /// Creating referance variable of IAdminInternetProviderRepository and injecting in Admin Internet Provider Services Constructor
        /// </summary>
        private readonly IAdminInternetProviderRepository _adminRepository;
        public AdminInternetProviderServices(IAdminInternetProviderRepository adminInternetProviderRepository)
        {
            _adminRepository = adminInternetProviderRepository;
        }
        /// <summary>
        /// Add new employee by admin in MongoDb collection
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public async Task<Employee> AddNewEmployee(Employee employee)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Add new internet services plan for customer
        /// </summary>
        /// <param name="plan"></param>
        /// <returns></returns>
        public async Task<Plan> AddNewPlan(Plan plan)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get all registred complaint for admin, From MongoDb collection
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Complaint>> AllRegisterComplaint()
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get complaint from MongoDb collection by complaintId
        /// </summary>
        /// <param name="complaintId"></param>
        /// <returns></returns>
        public async Task<Complaint> ComplaintById(string complaintId)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get Customer by Customer Id for Update customer
        /// </summary>
        /// <param name="CustomerId"></param>
        /// <returns></returns>
        public async Task<Customer> CustomerById(string CustomerId)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Delete an existing complaint by complaint Id
        /// </summary>
        /// <param name="complaintId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteComplaint(string complaintId)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Delete an existing Customer by Customer Id
        /// </summary>
        /// <param name="CustomerId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteCustomer(string CustomerId)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Delete an existing Employee by Employee Id
        /// </summary>
        /// <param name="EmployeeId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteEmployee(string EmployeeId)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get registred by employee Id
        /// </summary>
        /// <param name="EmployeeId"></param>
        /// <returns></returns>
        public async Task<Employee> EmployeeById(string EmployeeId)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Update an existing customer by customer Id in MongoDb collection
        /// </summary>
        /// <param name="CustomerId"></param>
        /// <param name="customer"></param>
        /// <returns></returns>
        public async Task<Customer> UpdateCustomer(string CustomerId, Customer customer)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Update an existing Employee by employee Id in MongoDb collection
        /// </summary>
        /// <param name="EmployeeId"></param>
        /// <param name="employee"></param>
        /// <returns></returns>
        public async Task<Employee> UpdateEmployee(string EmployeeId, Employee employee)
        {
            //do code here
            throw new NotImplementedException();
        }
    }
}
