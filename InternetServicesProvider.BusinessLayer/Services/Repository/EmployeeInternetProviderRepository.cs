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
    public class EmployeeInternetProviderRepository : IEmployeeInternetProviderRepository
    {
        /// <summary>
        /// Creating field and object or dbcontext and all collection, injecting IMongoDBContext
        /// in constructor and getting a Collection from MongoDb
        /// </summary>
        private readonly IMongoDBContext _mongoContext;
        private IMongoCollection<Complaint> _dbCOCollection;
        public EmployeeInternetProviderRepository(IMongoDBContext context)
        {
            _mongoContext = context;
            _dbCOCollection = _mongoContext.GetCollection<Complaint>(typeof(Complaint).Name);
        }
        /// <summary>
        /// Get all registred complaint for Employee, From MongoDb collection
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
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        /// <summary>
        /// Solved customer complaint by Employee
        /// </summary>
        /// <param name="complaintId"></param>
        /// <param name="complaint"></param>
        /// <returns></returns>
        public async Task<Complaint> SolvedComplaint(string complaintId, Complaint complaint)
        {
            if (complaint == null && complaintId == null)
            {
                throw new ArgumentNullException(typeof(Complaint).Name + "Object or may ComplaintId is Null");
            }
            var update = await _dbCOCollection.FindOneAndUpdateAsync(Builders<Complaint>.
                Filter.Eq("ComplaintId", complaint.ComplaintId), Builders<Complaint>.
                Update.Set("Subject", complaint.Subject).Set("Description", complaint.Description).Set("CustomerId", complaint.CustomerId)
                .Set("Email", complaint.Email).Set("IsSolved", complaint.IsSolved));
            return update;
        }
    }
}
