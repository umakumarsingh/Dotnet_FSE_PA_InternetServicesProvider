using InternetServicesProvider.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InternetServicesProvider.BusinessLayer.Interfaces
{
    public interface IInternetProviderServices
    {
        /// <summary>
        /// All Curd operation method
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Plan>> AllInternetPlan();
        Task<Plan> InternetPlanById(string planId);
        Task<IEnumerable<Plan>> FindInternetPlan(string planName);
        Task<Customer> RegisterCustomer(Customer customer);
        Task<Customer> CustomerById(string customerId);
        Task<Complaint> RegisterComplaint(Complaint complaint);
        Task<IEnumerable<Complaint>> ViewComplaint(string CuCoId);
        Task<BookedPlan> BookPlan(string planId, Customer customer);
        Task<Customer> VerifyCustomer(string customerId);
        Task<BookedPlan> BookedPlanByCustomerId(string customerId);
        IEnumerable<Plan> Plan();
    }
}
