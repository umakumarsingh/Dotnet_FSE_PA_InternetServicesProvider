using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InternetServicesProvider.Entities
{
    public class Complaint
    {
        [Key]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ComplaintId { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string CustomerId { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public bool IsSolved { get; set; }
    }
}
