using InternetServicesProvider.BusinessLayer.Interfaces;
using InternetServicesProvider.BusinessLayer.Services.Repository;
using InternetServicesProvider.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InternetServicesProvider.BusinessLayer.Services
{
    public class InternetProviderServices : IInternetProviderServices
    {
        /// <summary>
        /// Creating referance variable of IInternetProviderRepository and injecting in Internet Provider Services Constructor
        /// </summary>
        private readonly IInternetProviderRepository _internetRepository;
        public InternetProviderServices(IInternetProviderRepository internetProviderRepository)
        {
            _internetRepository = internetProviderRepository;
        }
        /// <summary>
        /// Get all internet services plan from MongoDb collection
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Plan>> AllInternetPlan()
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get Booked plan by customer Id.
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public async Task<BookedPlan> BookedPlanByCustomerId(string customerId)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Book Internet services plan for customer, for booking plan customer must be register
        /// </summary>
        /// <param name="planId"></param>
        /// <param name="customer"></param>
        /// <returns></returns>
        public async Task<BookedPlan> BookPlan(string planId, Customer customer)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// get customer by id, after customer register suscussfully.
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public async Task<Customer> CustomerById(string customerId)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Find internet plan by plan name
        /// </summary>
        /// <param name="planName"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Plan>> FindInternetPlan(string planName)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get internet plan by Id and see the details.
        /// </summary>
        /// <param name="planId"></param>
        /// <returns></returns>
        public async Task<Plan> InternetPlanById(string planId)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get plan list
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Plan> Plan()
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Register new complaint by customer, customer must be register first.
        /// </summary>
        /// <param name="complaint"></param>
        /// <returns></returns>
        public async Task<Complaint> RegisterComplaint(Complaint complaint)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Register new customer for book internet plan and raise complaint.
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public async Task<Customer> RegisterCustomer(Customer customer)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// verify customer for book internet plan and book complaint.
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public async Task<Customer> VerifyCustomer(string customerId)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// view complaint by complaint id and customer id
        /// </summary>
        /// <param name="CuCoId"></param>
        /// <returns></returns>
        public Task<IEnumerable<Complaint>> ViewComplaint(string CuCoId)
        {
            //do code here
            throw new NotImplementedException();
        }
    }
}
