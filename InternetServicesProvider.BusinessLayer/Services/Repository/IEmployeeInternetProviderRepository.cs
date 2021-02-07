using InternetServicesProvider.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InternetServicesProvider.BusinessLayer.Services.Repository
{
    public interface IEmployeeInternetProviderRepository
    {
        Task<IEnumerable<Complaint>> AllRegisterComplaint();
        Task<Complaint> ComplaintById(string complaintId);
        Task<Complaint> SolvedComplaint(string complaintId, Complaint complaint);
    }
}
