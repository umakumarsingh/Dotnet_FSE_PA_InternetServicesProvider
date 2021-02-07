using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternetServicesProvider.BusinessLayer.Interfaces;
using InternetServicesProvider.BusinessLayer.ViewModels;
using InternetServicesProvider.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InternetServicesProvider.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InternetServicesController : ControllerBase
    {
        /// <summary>
        /// Creating referance variable of IInternetProviderServices interface and injecting in InternetServicesController constructor
        /// </summary>
        private readonly IInternetProviderServices _internetServices;
        public InternetServicesController(IInternetProviderServices internetProviderServices)
        {
            _internetServices = internetProviderServices;
        }
        /// <summary>
        /// Get all internet services plan for Customer to show on internet services controller  default open
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<Plan>> AllInternetPlan()
        {
            return await _internetServices.AllInternetPlan();
        }
        /// <summary>
        /// Get internet services plan by plan id
        /// </summary>
        /// <param name="planId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("InternetPlanById/{PlanId}")]
        public async Task<IActionResult> InternetPlanById(string planId)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Find internet plan by plan name list.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("FindInternetPlan/{name}")]
        public async Task<IEnumerable<Plan>> FindInternetPlan(string name)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Register new customer for book any internet plan and raise a complaint.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("RegisterCustomer")]
        public async Task<IActionResult> RegisterNewCustomer([FromBody] CustomerViewModel model)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get customer details by customer Id, for registred customer. 
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("CustomerById/{customerId}")]
        public async Task<IActionResult> CustomerById(string customerId)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Register new complaint for booked internet plan.
        /// before register any complaint customer must be register first.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("RegisterComplaint")]
        public async Task<IActionResult> RegisterNewComplaint([FromBody] ComplaintViewModel model)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// View registred complaint by customer or by customer id and complaint Id
        /// </summary>
        /// <param name="ComplaintId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("ViewComplaint/{ComplaintId}")]
        public async Task<IEnumerable<Complaint>> ViewComplaint(string ComplaintId)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// book internet services plan by planId and customerId.
        /// before book any internet plan customer must be register first
        /// </summary>
        /// <param name="PlanId"></param>
        /// <param name="CustomerId"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("BookPlan/{PlanId}/{CustomerId}")]
        public async Task<IActionResult> BookNewPlan([FromBody] string PlanId, String CustomerId)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get booked plan details by customer Id after plan is booked.
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("BookedPlanById/{customerId}")]
        public async Task<IActionResult> BookedPlanById(string customerId)
        {
            //do code here
            throw new NotImplementedException();
        }
    }
}
