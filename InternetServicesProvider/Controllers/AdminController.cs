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
    public class AdminController : ControllerBase
    {
        /// <summary>
        /// Creating referance variable of IAdminInternetProviderServices interface and injecting in AdminController constructor
        /// </summary>
        private readonly IAdminInternetProviderServices _adminServices;
        public AdminController(IAdminInternetProviderServices adminInternetProviderServices)
        {
            _adminServices = adminInternetProviderServices;
        }
        /// <summary>
        /// Get all registred complaint for Admin...
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<Complaint>> AllRegisterComplaint()
        {
            return await _adminServices.AllRegisterComplaint();
        }
        /// <summary>
        /// Get complaint by Comlaint Id and show the details of complaint
        [HttpGet]
        [Route("ComplaintById/{complaintId}")]
        public async Task<IActionResult> ComplaintById(string complaintId)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Add new internet services plan for customer by admin.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddPlan")]
        public async Task<IActionResult> AddNewPlan([FromBody] PlanViewModel model)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Add new employee by admin for solving complaint of customer.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddEmployee")]
        public async Task<IActionResult> AddNewEmployee([FromBody] EmployeeViewModel model)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Remove an existing employee by admin
        /// </summary>
        /// <param name="EmployeeId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteEmployee/{EmployeeId}")]
        public async Task<IActionResult> DeleteEmployee(string EmployeeId)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Update an existing employee by Id
        /// </summary>
        /// <param name="EmployeeId"></param>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateEmployee/{EmployeeId}")]
        public async Task<IActionResult> UpdateEmployee(string EmployeeId, [FromBody] Employee employee)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Delete an existing Complaint by complaint Id
        /// </summary>
        /// <param name="complaintId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteComplaint/{complaintId}")]
        public async Task<IActionResult> DeleteComplaint(string complaintId)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Delete an existing Customer by Customer Id
        /// </summary>
        /// <param name="CustomerId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteCustomer/{CustomerId}")]
        public async Task<IActionResult> DeleteCustomer(string CustomerId)
        {
            //Do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Update an existing customer by Id
        /// </summary>
        /// <param name="CustomerId"></param>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateCustomer/{CustomerId}")]
        public async Task<IActionResult> UpdateCustomer(string CustomerId, [FromBody] Customer customer)
        {
            //Do code here
            throw new NotImplementedException();
        }
    }
}
