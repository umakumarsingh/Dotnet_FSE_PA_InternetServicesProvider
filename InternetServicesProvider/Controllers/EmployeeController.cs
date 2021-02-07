using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InternetServicesProvider.BusinessLayer.Interfaces;
using InternetServicesProvider.Entities;
using Microsoft.AspNetCore.Mvc;

namespace InternetServicesProvider.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        /// <summary>
        /// Creating referance variable of IEmployeeInternetProviderServices interface and injecting in EmployeeController constructor
        /// </summary>
        private readonly IEmployeeInternetProviderServices _employeeServices;
        public EmployeeController(IEmployeeInternetProviderServices employeeInternetProviderServices)
        {
            _employeeServices = employeeInternetProviderServices;
        }
        /// <summary>
        /// Get all registred complaint for employee that is solved or not.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<Complaint>> AllCustomerComplaint()
        {
            return await _employeeServices.AllRegisterComplaint();
        }
        /// <summary>
        /// View registred complaint by customer or by customer id and complaint Id
        /// </summary>
        /// <param name="CuCoId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("ViewComplaint/{ComplaintId}")]
        public async Task<Complaint> ViewComplaint(string ComplaintId)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Solved Customer complaint and make sure while passing complaint collection IsSolved must be true.
        /// </summary>
        /// <param name="ComplaintId"></param>
        /// <param name="complaint"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("SolvedComplaint/{ComplaintId}")]
        public async Task<IActionResult> SolvedComplaint(string ComplaintId, [FromBody] Complaint complaint)
        {
            //do code here
            throw new NotImplementedException();
        }
    }
}
