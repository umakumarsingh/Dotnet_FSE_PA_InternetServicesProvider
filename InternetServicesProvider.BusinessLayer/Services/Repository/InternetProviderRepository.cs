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
    public class InternetProviderRepository : IInternetProviderRepository
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
        public InternetProviderRepository(IMongoDBContext context)
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
        /// Get all Internet plan from MongoDb Collection
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Plan>> AllInternetPlan()
        {
            try
            {
                var list = _mongoContext.GetCollection<Plan>("Plan")
                .Find(Builders<Plan>.Filter.Empty, null).SortByDescending(e => e.PlanId);
                return await list.ToListAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Get Customer booked plan by Customer Id
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public async Task<BookedPlan> BookedPlanByCustomerId(string customerId)
        {
            try
            {
                var objectId = new ObjectId(customerId);
                FilterDefinition<BookedPlan> filter = Builders<BookedPlan>.Filter.Eq("CustomerId", objectId);
                _dbBPCollection = _mongoContext.GetCollection<BookedPlan>(typeof(BookedPlan).Name);
                return await _dbBPCollection.FindAsync(filter).Result.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Book New Internet Plan by Register Customer only
        /// </summary>
        /// <param name="planId"></param>
        /// <param name="customer"></param>
        /// <returns></returns>
        public async Task<BookedPlan> BookPlan(string planId, Customer customer)
        {

            try
            {
                var objectId = new ObjectId(planId);
                FilterDefinition<Plan> filter = Builders<Plan>.Filter.Eq("PlanId", objectId);
                _dbPCollection = _mongoContext.GetCollection<Plan>(typeof(Plan).Name);
                var plan =  await _dbPCollection.FindAsync(filter).Result.FirstOrDefaultAsync();
                var booked = new BookedPlan()
                {
                    UserName = customer.UserName,
                    CustomerId = customer.CustomerId,
                    PlanName = plan.PlanName,
                    Email = customer.Email,
                    Address = customer.Address
                };
                _dbBPCollection = _mongoContext.GetCollection<BookedPlan>(typeof(BookedPlan).Name);
                await _dbBPCollection.InsertOneAsync(booked);
                return booked;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Get registred customer by customer Id from MongoDb collection
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public async Task<Customer> CustomerById(string customerId)
        {
            try
            {
                var objectId = new ObjectId(customerId);
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
        /// Find Internet plan by plan Name from mongoDb collection
        /// </summary>
        /// <param name="planName"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Plan>> FindInternetPlan(string planName)
        {
            try
            {
                var filterBuilder = new FilterDefinitionBuilder<Plan>();
                var findName = filterBuilder.Eq(s => s.PlanName, planName);
                _dbPCollection = _mongoContext.GetCollection<Plan>(typeof(Plan).Name);
                var result = await _dbPCollection.FindAsync(findName).Result.ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Get Internet Plan by Plan Id from MongoDb Collection for Plan Details
        /// </summary>
        /// <param name="planId"></param>
        /// <returns></returns>
        public async Task<Plan> InternetPlanById(string planId)
        {
            try
            {
                var objectId = new ObjectId(planId);
                FilterDefinition<Plan> filter = Builders<Plan>.Filter.Eq("PlanId", objectId);
                _dbPCollection = _mongoContext.GetCollection<Plan>(typeof(Plan).Name);
                return await _dbPCollection.FindAsync(filter).Result.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Get Plan list for genrating dropdown list for any Supported UI
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Plan> Plan()
        {
            try
            {
                var list = _mongoContext.GetCollection<Plan>("Plan")
                .Find(Builders<Plan>.Filter.Empty, null).SortByDescending(e => e.PlanId);
                return list.ToList();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Register new complaint for register Customer
        /// </summary>
        /// <param name="complaint"></param>
        /// <returns></returns>
        public async Task<Complaint> RegisterComplaint(Complaint complaint)
        {
            try
            {
                if (complaint == null)
                {
                    throw new ArgumentNullException(typeof(Complaint).Name + "Object is Null");
                }
                _dbCOCollection = _mongoContext.GetCollection<Complaint>(typeof(Complaint).Name);
                await _dbCOCollection.InsertOneAsync(complaint);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return complaint;
        }
        /// <summary>
        /// Register new customer for book internet plan and raise a complaint
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public async Task<Customer> RegisterCustomer(Customer customer)
        {
            try
            {
                if (customer == null)
                {
                    throw new ArgumentNullException(typeof(Customer).Name + "Object is Null");
                }
                _dbCUCollection = _mongoContext.GetCollection<Customer>(typeof(Customer).Name);
                await _dbCUCollection.InsertOneAsync(customer);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return customer;
        }
        /// <summary>
        /// Verify customer using this method before book any Internet plan and complaint.
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public async Task<Customer> VerifyCustomer(string customerId)
        {
            try
            {
                var objectId = new ObjectId(customerId);
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
        /// find or view complaint for customer, enter CustomerId and ComplaintId
        /// </summary>
        /// <param name="CuCoId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Complaint>> ViewComplaint(string CuCoId)
        {
            try
            {
                var filterBuilder = new FilterDefinitionBuilder<Complaint>();
                var findComplaint = filterBuilder.Eq(s => s.CustomerId, CuCoId);
                var findComplaintBy = filterBuilder.Eq(s => s.ComplaintId, CuCoId.ToString());
                _dbCOCollection = _mongoContext.GetCollection<Complaint>(typeof(Complaint).Name);
                var result = await _dbCOCollection.FindAsync(findComplaint | findComplaintBy).Result.ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
