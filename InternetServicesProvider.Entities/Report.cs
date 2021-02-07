using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InternetServicesProvider.Entities
{
    public class Report
    {
        [Key]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ReportId { get; set; }
        [Required]
        public string ComplaintId { get; set; }
        [Required]
        public string EmployeeId { get; set; }
        [Required]
        public string Solution { get; set; }
        [Required]
        public int Rating { get; set; }
    }
}
