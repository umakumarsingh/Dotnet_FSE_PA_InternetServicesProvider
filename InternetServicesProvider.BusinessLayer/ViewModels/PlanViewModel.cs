using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InternetServicesProvider.BusinessLayer.ViewModels
{
    public class PlanViewModel
    {
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
