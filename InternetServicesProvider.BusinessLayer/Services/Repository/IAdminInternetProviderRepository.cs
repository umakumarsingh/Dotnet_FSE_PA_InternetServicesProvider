using InternetServicesProvider.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InternetServicesProvider.BusinessLayer.Services.Repository
{
    public interface IAdminInternetProviderRepository
    {
        Task<Plan> AddNewPlan(Plan plan);
        Task<Employee> AddNewEmployee(Employee employee);
        Task<Employee> EmployeeById(string EmployeeId);
        Task<bool> DeleteEmployee(string EmployeeId);
        Task<Employee> UpdateEmployee(string EmployeeId, Employee employee);
        Task<IEnumerable<Complaint>> AllRegisterComplaint();
        //Task<IEnumerable<Customer>> AllRegisterCustomer();
        Task<Complaint> ComplaintById(string complaintId);
        Task<bool> DeleteComplaint(string complaintId);
        Task<bool> DeleteCustomer(string CustomerId);
        Task<Customer> CustomerById(string CustomerId);
        Task<Customer> UpdateCustomer(string CustomerId, Customer customer);
    }
}
