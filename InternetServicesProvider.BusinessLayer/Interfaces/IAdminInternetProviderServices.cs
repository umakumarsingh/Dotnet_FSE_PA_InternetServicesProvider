using InternetServicesProvider.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InternetServicesProvider.BusinessLayer.Interfaces
{
    public interface IAdminInternetProviderServices
    {
        Task<Plan> AddNewPlan(Plan plan);
        Task<Employee> AddNewEmployee(Employee employee);
        Task<bool> DeleteEmployee(string EmployeeId);
        Task<Employee> EmployeeById(string EmployeeId);
        Task<Employee> UpdateEmployee(string EmployeeId, Employee employee);
        Task<IEnumerable<Complaint>> AllRegisterComplaint();
        Task<Complaint> ComplaintById(string complaintId);
        Task<bool> DeleteComplaint(string complaintId);
        Task<bool> DeleteCustomer(string CustomerId);
        Task<Customer> CustomerById(string CustomerId);
        Task<Customer> UpdateCustomer(string CustomerId, Customer customer);
    }
}
