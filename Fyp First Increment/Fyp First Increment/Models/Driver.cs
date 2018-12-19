using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fyp_First_Increment.Models
{
    public class Driver:Users
    {



        [Required(ErrorMessage = "Enter Driver Salary ")]
        [RegularExpression(@"^([0-9])[0-9]*[.]?[0-9]{1,6}$", ErrorMessage = "Only Numbers Allowed")]
        [MinLength(1)]
        [MaxLength(6)]
        public string DriverSalary { get; set; }



        [Required(ErrorMessage = "Enter Driver Experience ")]
        [MinLength(1)]
        [MaxLength(2)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Only Numbers Allowed")]
        public string DriverExperience { get; set; }
        
        
        
        [Required(ErrorMessage = "Required!")]
        public string DriverType { get; set; }
        
        
        
        [Required(ErrorMessage = "Required!")]
        public string DriverPostion { get; set; }
        
        
        
        [Required(ErrorMessage = "Required!")]
        public string DriverRouteCharge { get; set; }
        
        
        
        public int DriverCompanyId { get; set; }
        
        
        public int DriverUserId { get; set; }
    }
}