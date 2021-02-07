using InternetServicesProvider.BusinessLayer.Interfaces;
using InternetServicesProvider.BusinessLayer.Services.Repository;
using InternetServicesProvider.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InternetServicesProvider.BusinessLayer.Services
{
    public class EmployeeInternetProviderServices : IEmployeeInternetProviderServices
    {
        /// <summary>
        /// Creating referance variable of IEmployeeInternetProviderRepository and injecting in Employee Internet Provider Servicess Constructor
        /// </summary>
        private readonly IEmployeeInternetProviderRepository _employeeRepository;
        public EmployeeInternetProviderServices(IEmployeeInternetProviderRepository employeeInternetProviderRepository)
        {
            _employeeRepository = employeeInternetProviderRepository;
        }
        /// <summary>
        /// Get all register complaint for employee to sove it
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Complaint>> AllRegisterComplaint()
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// Get complaint by Id
        /// </summary>
        /// <param name="complaintId"></param>
        /// <returns></returns>
        public Task<Complaint> ComplaintById(string complaintId)
        {
            //do code here
            throw new NotImplementedException();
        }
        /// <summary>
        /// solved complaint by id and provide description
        /// </summary>
        /// <param name="complaintId"></param>
        /// <param name="complaint"></param>
        /// <returns></returns>
        public async Task<Complaint> SolvedComplaint(string complaintId, Complaint complaint)
        {
            //do code here
            throw new NotImplementedException();
        }
    }
}
