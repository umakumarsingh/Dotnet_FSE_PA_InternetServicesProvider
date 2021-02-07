using InternetServicesProvider.BusinessLayer.Interfaces;
using InternetServicesProvider.BusinessLayer.Services;
using InternetServicesProvider.BusinessLayer.Services.Repository;
using InternetServicesProvider.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace InternetServicesProvider.Test.TestCases
{
    public class ExceptionalTest
    {
        /// <summary>
        /// Creating Referance Variable of Service Interface and Mocking Repository Interface and class
        /// </summary>
        private readonly IInternetProviderServices _internetServices;
        private readonly IEmployeeInternetProviderServices _employeeServices;
        private readonly IAdminInternetProviderServices _adminServices;
        public readonly Mock<IInternetProviderRepository> service = new Mock<IInternetProviderRepository>();
        public readonly Mock<IEmployeeInternetProviderRepository> employeeService = new Mock<IEmployeeInternetProviderRepository>();
        public readonly Mock<IAdminInternetProviderRepository> adminService = new Mock<IAdminInternetProviderRepository>();
        private readonly BookedPlan _bookedPlan;
        private readonly Complaint _complaint;
        private readonly Customer _customer;
        private readonly Employee _employee;
        private readonly Plan _plan;
        public ExceptionalTest()
        {
            //Creating New mock Object with value.
            _internetServices = new InternetProviderServices(service.Object);
            _employeeServices = new EmployeeInternetProviderServices(employeeService.Object);
            _adminServices = new AdminInternetProviderServices(adminService.Object);
            _bookedPlan = new BookedPlan
            {
                BookedPlanId = "601eae5b130a5167ed16379c",
                UserName = "Kumar Sonu",
                CustomerId = "601e85459cce264b8403a8c1",
                PlanName = "Monthly",
                Email = "services@iiht.co.in",
                Address = "a/3 Banglore"
            };
            _complaint = new Complaint
            {
                ComplaintId = "601eae5b130a5167ed16379c",
                Subject = "Not Working",
                Description = "Internet Plan is not working",
                CustomerId = "601e85459cce264b8403a8c1",
                Email = "services@iiht.co.in",
                IsSolved = false
            };
            _customer = new Customer
            {
                CustomerId = "601e85459cce264b8403a8c1",
                UserName = "Kumar Sonu",
                PhoneNumber = 9631438121,
                Address = "a/3 Banglore",
                Email = "services@iiht.co.in",
                Age = 23,
                Region = "Bihar",
                BusinessType = "Home"
            };
            _employee = new Employee
            {
                EmployeeId = "601eae5b130a5167ed16379c",
                UserName = "umakumarsingh",
                PhoneNumber = 9865324578,
                Address = "12/23 Banglore Noth Aven",
                Email = "umasingh@iiht.com",
                Password = "123456"
            };
            _plan = new Plan
            {
                PlanId = "601eae5b130a5167ed16379c",
                PlanName = "Monthly",
                Description = "Get 30 GB Data",
                PlanExpiryDate = DateTime.Now
            };
        }
        /// <summary>
        /// Creating test output text file that store the result in boolean result
        /// </summary>
        static ExceptionalTest()
        {
            if (!File.Exists("../../../../output_exception_revised.txt"))
                try
                {
                    File.Create("../../../../output_exception_revised.txt").Dispose();
                }
                catch (Exception)
                {

                }
            else
            {
                File.Delete("../../../../output_exception_revised.txt");
                File.Create("../../../../output_exception_revised.txt").Dispose();
            }
        }
        /// <summary>
        /// Test for Register invalid Customer, if customer not null the test is faild.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_Invlid_Customer()
        {
            //Arrange
            bool res = false;
            var _customerUpdate = new Customer
            {
                CustomerId = "",
                UserName = "Kumar Sonu",
                PhoneNumber = 9631438121,
                Address = "a/3 Banglore",
                Email = "services@iiht.co.in",
                Age = 23,
                Region = "Bihar",
                BusinessType = "Home"
            };
            _customerUpdate = null;
            //Act
            service.Setup(repo => repo.RegisterCustomer(_customerUpdate)).ReturnsAsync(_customerUpdate = null);
            var result = await _internetServices.RegisterCustomer(_customerUpdate);
            if (result == null)
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_exception_revised.txt", "Testfor_Validate_Invlid_Customer=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Test for Register invalid Complaint, if complaint not null the test is faild.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_Invlid_RegisterComplaint()
        {
            //Arrange
            bool res = false;
            var _complaintCheck = new Complaint
            {
                ComplaintId = "",
                Subject = "Not Working",
                Description = "Internet Plan is not working",
                CustomerId = "",
                Email = "services@iiht.co.in",
                IsSolved = false
            };
            _complaintCheck = null;
            //Act
            service.Setup(repo => repo.RegisterComplaint(_complaintCheck)).ReturnsAsync(_complaintCheck = null);
            var result = await _internetServices.RegisterComplaint(_complaintCheck);
            if (result == null)
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_exception_revised.txt", "Testfor_Validate_Invlid_RegisterComplaint=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Test for Add invalid Plan, if Plan not null the test is faild.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_Invlid_Addnewplan()
        {
            //Arrange
            bool res = false;
            var _planInvalid = new Plan
            {
                PlanId = "",
                PlanName = "Monthly",
                Description = "Get 30 GB Data",
                PlanExpiryDate = DateTime.Now
            };
            _planInvalid = null;
            //Act
            adminService.Setup(repo => repo.AddNewPlan(_planInvalid)).ReturnsAsync(_planInvalid = null);
            var result = await _adminServices.AddNewPlan(_planInvalid);
            if (result == null)
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_exception_revised.txt", "Testfor_Validate_Invlid_Addnewplan=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Test for Add invalid Employee, if Employee not null the test is faild.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_Invlid_AddnewEmployee()
        {
            //Arrange
            bool res = false;
            var _employeeInvalid = new Employee
            {
                EmployeeId = "",
                UserName = "umakumarsingh",
                PhoneNumber = 9865324578,
                Address = "12/23 Banglore Noth Aven",
                Email = "umasingh@iiht.com",
                Password = "123456"
            };
            _employeeInvalid = null;
            //Act
            adminService.Setup(repo => repo.AddNewEmployee(_employeeInvalid)).ReturnsAsync(_employeeInvalid = null);
            var result = await _adminServices.AddNewEmployee(_employeeInvalid);
            if (result == null)
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_exception_revised.txt", "Testfor_Validate_Invlid_AddnewEmployee=" + res + "\n");
            return res;
        }

    }
}
