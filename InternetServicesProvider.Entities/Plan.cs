using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InternetServicesProvider.Entities
{
    public class Plan
    {
        [Key]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [Display(Name = "Plan Id")]
        public string PlanId { get; set; }
        [Required]
        [Display(Name = "Plan Name")]
        public string PlanName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Plan Expiry Date")]
        public DateTime PlanExpiryDate { get; set; }
    }
}
