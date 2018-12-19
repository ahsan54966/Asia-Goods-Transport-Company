using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fyp_First_Increment.Models
{
    public class Report
    {
        [Required(ErrorMessage = "Field Required!")]
        public string ReportVehicleNumber { get; set; }
        [Required(ErrorMessage = "Field Required!")]
        public DateTime ReportDateFrom { get; set; }
        [Required(ErrorMessage = "Field Required!")]
        public DateTime ReportDateTo { get; set; }
        [Required(ErrorMessage = "Field Required!")]
        //This Field ForProfit Calculated Value
        public int ReportProfit { get; set; }
        [Required(ErrorMessage = "Field Required!")]
        // For driver Bus or Truck
        public string AreaType { get; set; }
        [Required(ErrorMessage = "Field Required!")]
        public string DriverCat { get; set; }
        // For Vehicle Type Bus or Truck
        [Required(ErrorMessage = "Field Required!")]
        public string VehicleType { get; set; }
        // ForDistinguish Report is 15, 7 days, Monthly and Yearly
        [Required(ErrorMessage = "Field Required!")]
        public string ReportDurationType { get; set; }
        [Required(ErrorMessage = "Field Required!")]
        public string VehicleManufacture { get; set; }
        public int CompanyId { get; set; }
    }
}