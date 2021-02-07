using InternetServicesProvider.DataLayer;
using InternetServicesProvider.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InternetServicesProvider.BusinessLayer.Services.Repository
{
    public class AdminInternetProviderRepository : IAdminInternetProviderRepository
    {
        /// <summary>
        /// Creating field and object or dbcontext and all collection, injecting IMongoDBContext
        /// in constructor and getting a Collection from MongoDb
        /// </summary>
        private readonly IMongoDBContext _mongoContext;
        private IMongoCollection<BookedPlan> _dbBPCollection;
        private IMongoCollection<Complaint> _dbCOCollection;
        private IMongoCollection<Customer> _dbCUCollection;
        private IMongoCollection<Employee> _dbECollection;
        private IMongoCollection<Plan> _dbPCollection;
        private IMongoCollection<Report> _dbRCollection;
        public AdminInternetProviderRepository(IMongoDBContext context)
        {
            _mongoContext = context;
            _dbBPCollection = _mongoContext.GetCollection<BookedPlan>(typeof(BookedPlan).Name);
            _dbCOCollection = _mongoContext.GetCollection<Complaint>(typeof(Complaint).Name);
            _dbCUCollection = _mongoContext.GetCollection<Customer>(typeof(Customer).Name);
            _dbECollection = _mongoContext.GetCollection<Employee>(typeof(Employee).Name);
            _dbPCollection = _mongoContext.GetCollection<Plan>(typeof(Plan).Name);
            _dbRCollection = _mongoContext.GetCollection<Report>(typeof(Report).Name);
        }
        /// <summary>
        /// Add new employee by admin in MongoDb collection
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public async Task<Employee> AddNewEmployee(Employee employee)
        {
            try
            {
                if (employee == null)
                {
                    throw new ArgumentNullException(typeof(Employee).Name + "Object is Null");
                }
                _dbECollection = _mongoContext.GetCollection<Employee>(typeof(Employee).Name);
                await _dbECollection.InsertOneAsync(employee);
            }
            catch(Exception ex)
            {
                throw (ex);
            }
            return employee;
        }
        /// <summary>
        /// Add new internet services plan
        /// </summary>
        /// <param name="plan"></param>
        /// <returns></returns>
        public async Task<Plan> AddNewPlan(Plan plan)
        {
            try
            {
                if (plan == null)
                {
                    throw new ArgumentNullException(typeof(Plan).Name + "Object is Null");
                }
                _dbPCollection = _mongoContext.GetCollection<Plan>(typeof(Plan).Name);
                await _dbPCollection.InsertOneAsync(plan);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return plan;
        }
        /// <summary>
        /// Get all registred complaint for admin, From MongoDb collection
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Complaint>> AllRegisterComplaint()
        {
            try
            {
                var list = _mongoContext.GetCollection<Complaint>("Complaint")
                .Find(Builders<Complaint>.Filter.Empty, null).SortByDescending(e => e.ComplaintId);
                return await list.ToListAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Get complaint from MongoDb collection by complaintId
        /// </summary>
        /// <param name="complaintId"></param>
        /// <returns></returns>
        public async Task<Complaint> ComplaintById(string complaintId)
        {
            try
            {
                var objectId = new ObjectId(complaintId);
                FilterDefinition<Complaint> filter = Builders<Complaint>.Filter.Eq("complaintId", objectId);
                _dbCOCollection = _mongoContext.GetCollection<Complaint>(typeof(Complaint).Name);
                return await _dbCOCollection.FindAsync(filter).Result.FirstOrDefaultAsync();
            }
            catch(Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Get Customer bycustomer by Id
        /// </summary>
        /// <param name="CustomerId"></param>
        /// <returns></returns>
        public async Task<Customer> CustomerById(string CustomerId)
        {
            try
            {
                var objectId = new ObjectId(CustomerId);
                FilterDefinition<Customer> filter = Builders<Customer>.Filter.Eq("CustomerId", objectId);
                _dbCUCollection = _mongoContext.GetCollection<Customer>(typeof(Customer).Name);
                return await _dbCUCollection.FindAsync(filter).Result.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Delete an existing complaint by complaint Id
        /// </summary>
        /// <param name="complaintId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteComplaint(string complaintId)
        {
            try
            {
                var objectId = new ObjectId(complaintId);
                FilterDefinition<Complaint> filter = Builders<Complaint>.Filter.Eq("ComplaintId", objectId);
                var result = await _dbCOCollection.DeleteOneAsync(filter);
                return result.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Delete an existing Customer by Customer Id
        /// </summary>
        /// <param name="CustomerId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteCustomer(string CustomerId)
        {
            try
            {
                var objectId = new ObjectId(CustomerId);
                FilterDefinition<Customer> filter = Builders<Customer>.Filter.Eq("CustomerId", objectId);
                var result = await _dbCUCollection.DeleteOneAsync(filter);
                return result.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Delete an existing Employee by Employee Id
        /// </summary>
        /// <param name="EmployeeId"></param>
        /// <returns></returns>
        public async Task<bool> DeleteEmployee(string EmployeeId)
        {
            try
            {
                var objectId = new ObjectId(EmployeeId);
                FilterDefinition<Employee> filter = Builders<Employee>.Filter.Eq("EmployeeId", objectId);
                var result = await _dbECollection.DeleteOneAsync(filter);
                return result.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Get registred employee by Employee Id
        /// </summary>
        /// <param name="EmployeeId"></param>
        /// <returns></returns>
        public async Task<Employee> EmployeeById(string EmployeeId)
        {
            try
            {
                var objectId = new ObjectId(EmployeeId);
                FilterDefinition<Employee> filter = Builders<Employee>.Filter.Eq("EmployeeId", objectId);
                _dbECollection = _mongoContext.GetCollection<Employee>(typeof(Employee).Name);
                return await _dbECollection.FindAsync(filter).Result.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// Update an existing customer by customer Id in MongoDb collection
        /// </summary>
        /// <param name="CustomerId"></param>
        /// <param name="customer"></param>
        /// <returns></returns>
        public async Task<Customer> UpdateCustomer(string CustomerId, Customer customer)
        {
            if (customer == null && CustomerId == null)
            {
                throw new ArgumentNullException(typeof(Customer).Name + "Object or may CustomerId is Null");
            }
            var update = await _dbCUCollection.FindOneAndUpdateAsync(Builders<Customer>.
                Filter.Eq("CustomerId", customer.CustomerId), Builders<Customer>.
                Update.Set("UserName", customer.UserName).Set("PhoneNumber", customer.PhoneNumber).Set("Address", customer.Address)
                .Set("Email", customer.Email).Set("Age", customer.Age).Set("Region", customer.Region)
                .Set("BusinessType", customer.BusinessType));
            return update;
        }
        /// <summary>
        /// Update an existing Employee by employee Id in MongoDb collection
        /// </summary>
        /// <param name="EmployeeId"></param>
        /// <param name="employee"></param>
        /// <returns></returns>
        public async Task<Employee> UpdateEmployee(string EmployeeId, Employee employee)
        {
            if (employee == null && EmployeeId == null)
            {
                throw new ArgumentNullException(typeof(Employee).Name + "Object or may EmployeeId is Null");
            }
            var update = await _dbECollection.FindOneAndUpdateAsync(Builders<Employee>.
                Filter.Eq("EmployeeId", employee.EmployeeId), Builders<Employee>.
                Update.Set("UserName", employee.UserName).Set("PhoneNumber", employee.PhoneNumber).Set("Address", employee.Address)
                .Set("Email", employee.Email).Set("Password", employee.Password));
            return update;
        }
    }
}
