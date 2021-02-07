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
    public class FunctionalTest
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
        public FunctionalTest()
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
        static FunctionalTest()
        {
            if (!File.Exists("../../../../output_revised.txt"))
                try
                {
                    File.Create("../../../../output_revised.txt").Dispose();
                }
                catch (Exception)
                {

                }
            else
            {
                File.Delete("../../../../output_revised.txt");
                File.Create("../../../../output_revised.txt").Dispose();
            }
        }
        /// <summary>
        /// Get all Internet sevices plan to validate all Services Plan
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_GetAllInternetPlan()
        {
            //Arrange
            var res = false;
            //Action
            service.Setup(repos => repos.AllInternetPlan());
            var result = await _internetServices.AllInternetPlan();
            //Assertion
            if (result != null)
            {
                res = true;
            }
            //Assert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_Validate_GetAllInternetPlan=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Test for get Internet plan by Plan Id, if not exists test failed or passesd if its true.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_GetInternetPlanById()
        {
            //Arrange
            var res = false;
            //Action
            service.Setup(repos => repos.InternetPlanById(_plan.PlanId)).ReturnsAsync(_plan);
            var result = await _internetServices.InternetPlanById(_plan.PlanId);
            //Assertion
            if (result != null)
            {
                res = true;
            }
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_GetInternetPlanById=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Test for get internet services plan by Name, if not exists test failed or passesd if its true.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_FindInternetPlanByName()
        {
            //Arrange
            var res = false;
            //Action
            service.Setup(repos => repos.FindInternetPlan(_plan.PlanName));
            var result = await _internetServices.FindInternetPlan(_plan.PlanName);
            //Assertion
            if (result != null)
            {
                res = true;
            }
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_FindInternetPlanByName=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Test for Register a Customer and return Customer object
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_RegisterCustomer()
        {
            //Arrange
            var res = false;
            //Action
            service.Setup(repos => repos.RegisterCustomer(_customer)).ReturnsAsync(_customer);
            var result = await _internetServices.RegisterCustomer(_customer);
            //Assertion
            if (result != null)
            {
                res = true;
            }
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_RegisterCustomer=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Test for get Customer by Customer Id, if not exists test failed or passesd if its true.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_GetCustomerById()
        {
            //Arrange
            var res = false;
            //Action
            service.Setup(repos => repos.CustomerById(_customer.CustomerId)).ReturnsAsync(_customer);
            var result = await _internetServices.CustomerById(_customer.CustomerId);
            //Assertion
            if (result != null)
            {
                res = true;
            }
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_GetCustomerById=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Test for Book internet Plan and return BookPlan object
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_New_BookPlan()
        {
            //Arrange
            var res = false;
            //Action
            service.Setup(repos => repos.BookPlan(_plan.PlanId, _customer)).ReturnsAsync(_bookedPlan);
            var result = await _internetServices.BookPlan(_plan.PlanId, _customer);
            //Assertion
            if (result != null)
            {
                res = true;
            }
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_New_BookPlan=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Test for Register Complaint and return Complant object
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_New_RegisterComplaint()
        {
            //Arrange
            var res = false;
            //Action
            service.Setup(repos => repos.RegisterComplaint(_complaint)).ReturnsAsync(_complaint);
            var result = await _internetServices.RegisterComplaint(_complaint);
            //Assertion
            if (result != null)
            {
                res = true;
            }
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_New_RegisterComplaint=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Test for get internet services plan by Name, if not exists test failed or passesd if its true.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_ViewComplaint_ByComplaintId()
        {
            //Arrange
            var res = false;
            //Action
            service.Setup(repos => repos.ViewComplaint(_customer.CustomerId));
            var result = await _internetServices.ViewComplaint(_customer.CustomerId);
            //Assertion
            if (result != null)
            {
                res = true;
            }
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_ViewComplaint_ByComplaintId=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Test for verify Customer by Customer Id, if not exists test failed or passesd if its true.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_VerifyCustomerById()
        {
            //Arrange
            var res = false;
            //Action
            service.Setup(repos => repos.VerifyCustomer(_customer.CustomerId)).ReturnsAsync(_customer);
            var result = await _internetServices.VerifyCustomer(_customer.CustomerId);
            //Assertion
            if (result != null)
            {
                res = true;
            }
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_VerifyCustomerById=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Test for verify get Booked Plan by Customer Id, if not exists test failed or passesd if its true.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_BookedPlanByCustomerId()
        {
            //Arrange
            var res = false;
            //Action
            service.Setup(repos => repos.BookedPlanByCustomerId(_customer.CustomerId)).ReturnsAsync(_bookedPlan);
            var result = await _internetServices.BookedPlanByCustomerId(_customer.CustomerId);
            //Assertion
            if (result != null)
            {
                res = true;
            }
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_BookedPlanByCustomerId=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Get all Internet sevices plan to create dropdown list
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_GetPlanList()
        {
            //Arrange
            var res = false;
            //Action
            service.Setup(repos => repos.Plan());
            var result = _internetServices.Plan();
            //Assertion
            if (result != null)
            {
                res = true;
            }
            //Assert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_Validate_GetPlanList=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Get all Register complaint to validate all Complaint
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_GetAllRegisterComplaint()
        {
            //Arrange
            var res = false;
            //Action
            employeeService.Setup(repos => repos.AllRegisterComplaint());
            var result = await _employeeServices.AllRegisterComplaint();
            //Assertion
            if (result != null)
            {
                res = true;
            }
            //Assert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_Validate_GetAllRegisterComplaint=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Test to verify get complaint by complaint Id
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_GetComplaintById()
        {
            //Arrange
            var res = false;
            //Action
            employeeService.Setup(repos => repos.ComplaintById(_complaint.ComplaintId)).ReturnsAsync(_complaint);
            var result = await _employeeServices.ComplaintById(_complaint.ComplaintId);
            //Assertion
            if (result != null)
            {
                res = true;
            }
            //Assert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_Validate_GetComplaintById=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Using the test method try to solved existing Complaint by Complaint Id and Complaint Collection
        /// if get updated then Passed to true.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_SolvedComplaint()
        {
            //Arrange
            bool res = false;
            var complaintSolved = new Complaint
            {
                ComplaintId = "601e85459cce264b8403a8c1",
                Subject = "Not Working",
                Description = "Internet Plan is not working",
                CustomerId = "601e85459cce264b8403a8c1",
                Email = "services@iiht.co.in",
                IsSolved = true
            };
            //Act
            employeeService.Setup(repo => repo.SolvedComplaint(complaintSolved.ComplaintId, complaintSolved)).ReturnsAsync(complaintSolved);
            var result = await _employeeServices.SolvedComplaint(complaintSolved.ComplaintId, complaintSolved);
            if (result == complaintSolved)
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_Validate_SolvedComplaint=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Test for add new plan to mongodDb collction and return plan object
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_AddNewInternetPlan()
        {
            //Arrange
            var res = false;
            //Action
            adminService.Setup(repos => repos.AddNewPlan(_plan)).ReturnsAsync(_plan);
            var result = await _adminServices.AddNewPlan(_plan);
            //Assertion
            if (result != null)
            {
                res = true;
            }
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_AddNewInternetPlan=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Test for add new Employee to mongodDb collction and return Employee object
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_AddNewApplicationEmployee()
        {
            //Arrange
            var res = false;
            //Action
            adminService.Setup(repos => repos.AddNewEmployee(_employee)).ReturnsAsync(_employee);
            var result = await _adminServices.AddNewEmployee(_employee);
            //Assertion
            if (result != null)
            {
                res = true;
            }
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_AddNewApplicationEmployee=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Using the test method try to delete an existing employee by employee Id, if get then Passed to true
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> TestFor_DeleteEmployee()
        {
            //Arrange
            var res = false;
            //Action
            adminService.Setup(repos => repos.DeleteEmployee(_employee.EmployeeId)).ReturnsAsync(true);
            var resultDelete = await _adminServices.DeleteEmployee(_employee.EmployeeId);
            //Assertion
            if (resultDelete == true)
            {
                res = true;
            }
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "TestFor_DeleteAppointment=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Test to verify get employee by employee Id
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_GetEmployeeById()
        {
            //Arrange
            var res = false;
            //Action
            adminService.Setup(repos => repos.EmployeeById(_employee.EmployeeId)).ReturnsAsync(_employee);
            var result = await _adminServices.EmployeeById(_employee.EmployeeId);
            //Assertion
            if (result != null)
            {
                res = true;
            }
            //Assert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_Validate_GetEmployeeById=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Using the test method try to update existing Employee by Employee Id and Employee Collection
        /// if get updated then Passed to true.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_UpdateEmployee()
        {
            //Arrange
            bool res = false;
            var employeeUpdate = new Employee
            {
                EmployeeId = "601eae5b130a5167ed16379c",
                UserName = "umakumarsingh",
                PhoneNumber = 9865324578,
                Address = "12/23 Banglore Noth Aven",
                Email = "umasingh@iiht.com",
                Password = "123456"
            };
            //Act
            adminService.Setup(repo => repo.UpdateEmployee(employeeUpdate.EmployeeId, employeeUpdate)).ReturnsAsync(employeeUpdate);
            var result = await _adminServices.UpdateEmployee(employeeUpdate.EmployeeId, employeeUpdate);
            if (result == employeeUpdate)
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_Validate_UpdateEmployee=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Get all Internet sevices Registred Complaint to validate
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_AllRegisterComplaint()
        {
            //Arrange
            var res = false;
            //Action
            adminService.Setup(repos => repos.AllRegisterComplaint());
            var result = await _adminServices.AllRegisterComplaint();
            //Assertion
            if (result != null)
            {
                res = true;
            }
            //Assert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_Validate_AllRegisterComplaint=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Test to verify get Complaint by Complaint Id
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_ComplaintById()
        {
            //Arrange
            var res = false;
            //Action
            adminService.Setup(repos => repos.ComplaintById(_complaint.ComplaintId)).ReturnsAsync(_complaint);
            var result = await _adminServices.ComplaintById(_complaint.ComplaintId);
            //Assertion
            if (result != null)
            {
                res = true;
            }
            //Assert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_Validate_ComplaintById=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Using the test method try to delete an existing Complaint by emplaint Id, if get then Passed to true
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> TestFor_DeleteComplaint()
        {
            //Arrange
            var res = false;
            //Action
            adminService.Setup(repos => repos.DeleteComplaint(_complaint.ComplaintId)).ReturnsAsync(true);
            var resultDelete = await _adminServices.DeleteComplaint(_complaint.ComplaintId);
            //Assertion
            if (resultDelete == true)
            {
                res = true;
            }
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "TestFor_DeleteComplaint=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Using the test method try to delete an existing Complaint by emplaint Id, if get then Passed to true
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> TestFor_DeleteCustomer()
        {
            //Arrange
            var res = false;
            //Action
            adminService.Setup(repos => repos.DeleteCustomer(_customer.CustomerId)).ReturnsAsync(true);
            var resultDelete = await _adminServices.DeleteCustomer(_customer.CustomerId);
            //Assertion
            if (resultDelete == true)
            {
                res = true;
            }
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "TestFor_DeleteCustomer=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Test to verify get Customer by Customer Id
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_CustomerById()
        {
            //Arrange
            var res = false;
            //Action
            adminService.Setup(repos => repos.CustomerById(_customer.CustomerId)).ReturnsAsync(_customer);
            var result = await _adminServices.CustomerById(_customer.CustomerId);
            //Assertion
            if (result != null)
            {
                res = true;
            }
            //Assert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_Validate_CustomerById=" + res + "\n");
            return res;
        }
        /// <summary>
        /// Using the test method try to update existing Customer by Customer Id and customer Collection
        /// if get updated then Passed to true.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task<bool> Testfor_Validate_UpdateCustomer()
        {
            //Arrange
            bool res = false;
            var customerUpdate = new Customer
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
            //Act
            adminService.Setup(repo => repo.UpdateCustomer(customerUpdate.CustomerId, customerUpdate)).ReturnsAsync(customerUpdate);
            var result = await _adminServices.UpdateCustomer(customerUpdate.CustomerId, customerUpdate);
            if (result == customerUpdate)
            {
                res = true;
            }
            //Asert
            //final result displaying in text file
            await File.AppendAllTextAsync("../../../../output_revised.txt", "Testfor_Validate_UpdateCustomer=" + res + "\n");
            return res;
        }
    }
}
