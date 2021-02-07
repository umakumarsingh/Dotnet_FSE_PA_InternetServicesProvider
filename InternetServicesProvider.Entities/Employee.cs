using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InternetServicesProvider.Entities
{
    public class Employee
    {
        [Key]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string EmployeeId { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        public Double PhoneNumber { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
