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
    public class BoundaryTest
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
        public BoundaryTest()
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
        static BoundaryTest()
        {
            if (!File.Exists("../../../../output_boundary_revised.txt"))
                try
                {
                    File.Create("../../../../output_boundary_revised.txt").Dispose();
                }
                catch (Exception)
                {

                }
            else
            {
                File.Delete("../../../../output_boundary_revised.txt");
                File.Create("../../../../output_boundary_revised.txt").Dispose();
            }
        }
        /// <summary>
        /// Test to validate Customer Id is return valid or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_ValidateCustomerId()
        {
            //Arrange
            bool res = false;
            //Act
            service.Setup(repo => repo.RegisterCustomer(_customer)).ReturnsAsync(_customer);
            var result = await _internetServices.RegisterCustomer(_customer);
            if (result.CustomerId == _customer.CustomerId)
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_boundary_revised.txt", "Testfor_ValidateCustomerId=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Test to validate Customer UserName is not Empty
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_ValidateCustomer_UserName_EmptyString()
        {
            //Arrange
            bool res = false;
            //Act
            service.Setup(repo => repo.RegisterCustomer(_customer)).ReturnsAsync(_customer);
            var result = await _internetServices.RegisterCustomer(_customer);
            if (result.UserName != "")
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_boundary_revised.txt", "Testfor_ValidateCustomer_UserName_EmptyString=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Test to validate Customer PhoneNumber is not Empty
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_ValidateCustomer_PhoneNumber()
        {
            //Arrange
            bool res = false;
            //Act
            service.Setup(repo => repo.RegisterCustomer(_customer)).ReturnsAsync(_customer);
            var result = await _internetServices.RegisterCustomer(_customer);
            if (result.PhoneNumber == _customer.PhoneNumber)
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_boundary_revised.txt", "Testfor_ValidateCustomer_PhoneNumber=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Test to validate Customer Address is not Empty
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_ValidateCustomer_Address_EmptyString()
        {
            //Arrange
            bool res = false;
            //Act
            service.Setup(repo => repo.RegisterCustomer(_customer)).ReturnsAsync(_customer);
            var result = await _internetServices.RegisterCustomer(_customer);
            if (result.Address != "")
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_boundary_revised.txt", "Testfor_ValidateCustomer_Address_EmptyString=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Test to validate Customer Email Address is not Empty
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_ValidateCustomer_Emali_Address_EmptyString()
        {
            //Arrange
            bool res = false;
            //Act
            service.Setup(repo => repo.RegisterCustomer(_customer)).ReturnsAsync(_customer);
            var result = await _internetServices.RegisterCustomer(_customer);
            if (result.Email != "")
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_boundary_revised.txt", "Testfor_ValidateCustomer_Emali_Address_EmptyString=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Test to validate Customer Age is not Empty
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_ValidateCustomer_Age_EmptyValue()
        {
            //Arrange
            bool res = false;
            //Act
            service.Setup(repo => repo.RegisterCustomer(_customer)).ReturnsAsync(_customer);
            var result = await _internetServices.RegisterCustomer(_customer);
            if (result.Age != 0)
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_boundary_revised.txt", "Testfor_ValidateCustomer_Age_EmptyValue=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Test to validate Customer Region is not Empty
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_ValidateCustomer_Region_EmptyString()
        {
            //Arrange
            bool res = false;
            //Act
            service.Setup(repo => repo.RegisterCustomer(_customer)).ReturnsAsync(_customer);
            var result = await _internetServices.RegisterCustomer(_customer);
            if (result.Region != "")
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_boundary_revised.txt", "Testfor_ValidateCustomer_Region_EmptyString=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Test to validate Customer BusinessType is not Empty
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_ValidateCustomer_BusinessType_EmptyString()
        {
            //Arrange
            bool res = false;
            //Act
            service.Setup(repo => repo.RegisterCustomer(_customer)).ReturnsAsync(_customer);
            var result = await _internetServices.RegisterCustomer(_customer);
            if (result.BusinessType != "")
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_boundary_revised.txt", "Testfor_ValidateCustomer_BusinessType_EmptyString=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Test to validate Complaint Id is return valid or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_ValidateComplaintId()
        {
            //Arrange
            bool res = false;
            //Act
            service.Setup(repo => repo.RegisterComplaint(_complaint)).ReturnsAsync(_complaint);
            var result = await _internetServices.RegisterComplaint(_complaint);
            if (result.CustomerId == _customer.CustomerId)
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_boundary_revised.txt", "Testfor_ValidateComplaintId=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Test to validate Complaint Subject is not Empty
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_ValidateComplaint_Subject_EmptyString()
        {
            //Arrange
            bool res = false;
            //Act
            service.Setup(repo => repo.RegisterComplaint(_complaint)).ReturnsAsync(_complaint);
            var result = await _internetServices.RegisterComplaint(_complaint);
            if (result.Subject != "")
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_boundary_revised.txt", "Testfor_ValidateComplaint_Subject_EmptyString=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Test to validate Complaint Description is not Empty
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_ValidateComplaint_Description_EmptyString()
        {
            //Arrange
            bool res = false;
            //Act
            service.Setup(repo => repo.RegisterComplaint(_complaint)).ReturnsAsync(_complaint);
            var result = await _internetServices.RegisterComplaint(_complaint);
            if (result.Description != "")
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_boundary_revised.txt", "Testfor_ValidateComplaint_Description_EmptyString=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Test to validate Complaint CustomerId is not 0
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_ValidateComplaint_CustomerId_EmptyValue()
        {
            //Arrange
            bool res = false;
            //Act
            service.Setup(repo => repo.RegisterComplaint(_complaint)).ReturnsAsync(_complaint);
            var result = await _internetServices.RegisterComplaint(_complaint);
            if (result.CustomerId == _complaint.CustomerId)
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_boundary_revised.txt", "Testfor_ValidateComplaint_CustomerId_EmptyString=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Test to validate Complaint Email Id is not Empty
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_ValidateComplaint_Email_EmptyString()
        {
            //Arrange
            bool res = false;
            //Act
            service.Setup(repo => repo.RegisterComplaint(_complaint)).ReturnsAsync(_complaint);
            var result = await _internetServices.RegisterComplaint(_complaint);
            if (result.Email != "")
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_boundary_revised.txt", "Testfor_ValidateComplaint_Email_EmptyString=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Test to validate BookedPlan Id is return valid or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_ValidateBookedPlanId()
        {
            //Arrange
            bool res = false;
            //Act
            service.Setup(repo => repo.BookPlan(_plan.PlanId, _customer)).ReturnsAsync(_bookedPlan);
            var result = await _internetServices.BookPlan(_plan.PlanId, _customer);
            if (result.BookedPlanId == _bookedPlan.BookedPlanId)
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_boundary_revised.txt", "Testfor_ValidateBookedPlanId=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Test to validate BookedPlan UserName is return valid or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_ValidateBookedPlan_UserName_EmptyString()
        {
            //Arrange
            bool res = false;
            //Act
            service.Setup(repo => repo.BookPlan(_plan.PlanId, _customer)).ReturnsAsync(_bookedPlan);
            var result = await _internetServices.BookPlan(_plan.PlanId, _customer);
            if (result.UserName != "")
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_boundary_revised.txt", "Testfor_ValidateBookedPlan_UserName=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Test to validate BookedPlan Customer Id is return valid or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_ValidateBookedPlan_CustomerId_EmptyValue()
        {
            //Arrange
            bool res = false;
            //Act
            service.Setup(repo => repo.BookPlan(_plan.PlanId, _customer)).ReturnsAsync(_bookedPlan);
            var result = await _internetServices.BookPlan(_plan.PlanId, _customer);
            if (result.CustomerId == _customer.CustomerId)
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_boundary_revised.txt", "Testfor_ValidateBookedPlan_CustomerId_EmptyValue=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Test to validate BookedPlan PlanName is return valid or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_ValidateBookedPlan_PlanName_EmptyString()
        {
            //Arrange
            bool res = false;
            //Act
            service.Setup(repo => repo.BookPlan(_plan.PlanId, _customer)).ReturnsAsync(_bookedPlan);
            var result = await _internetServices.BookPlan(_plan.PlanId, _customer);
            if (result.PlanName != "")
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_boundary_revised.txt", "Testfor_ValidateBookedPlan_PlanName_EmptyString=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Test to validate BookedPlan Email is return valid or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_ValidateBookedPlan_Email_EmptyString()
        {
            //Arrange
            bool res = false;
            //Act
            service.Setup(repo => repo.BookPlan(_plan.PlanId, _customer)).ReturnsAsync(_bookedPlan);
            var result = await _internetServices.BookPlan(_plan.PlanId, _customer);
            if (result.Email != "")
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_boundary_revised.txt", "Testfor_ValidateBookedPlan_Email_EmptyString=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Test to validate BookedPlan Address is return valid or not
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_ValidateBookedPlan_Address_EmptyString()
        {
            //Arrange
            bool res = false;
            //Act
            service.Setup(repo => repo.BookPlan(_plan.PlanId, _customer)).ReturnsAsync(_bookedPlan);
            var result = await _internetServices.BookPlan(_plan.PlanId, _customer);
            if (result.Address != "")
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_boundary_revised.txt", "Testfor_ValidateBookedPlan_Address_EmptyString=" + res + "\n");
            return res;
        }

    }
}
