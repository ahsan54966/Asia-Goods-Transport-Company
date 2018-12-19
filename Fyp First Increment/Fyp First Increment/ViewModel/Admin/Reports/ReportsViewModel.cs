using Fyp_First_Increment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Fyp_First_Increment.ViewModel.Admin.Reports
{
    public class ReportsViewModel
    {
        [Required(ErrorMessage = "Field Required!")]
        public string ReportVehicleNumber { get; set; }
        [DisplayFormat(DataFormatString = "{d}")]
        [Required(ErrorMessage = "Field Required!")]
        public DateTime ReportDateFrom { get; set; }
        [DisplayFormat(DataFormatString = "{d}")]
        [Required(ErrorMessage = "Field Required!")]
        public DateTime ReportDateTo { get; set; }
        //This Field ForProfit Calculated Value
        [Required(ErrorMessage = "Field Required!")]
        public int ReportProfit { get; set; }
        // For Area to identify  Bus or Truck for DriverReport
        [Required(ErrorMessage = "Field Required!")]
        public string AreaType { get; set; }
        [Required(ErrorMessage = "Field Required!")]
        public string DriverCat { get; set; }
        // For Vehicle Type Bus or Truck
        [Required(ErrorMessage = "Field Required!")]
        public string VehicleType { get; set; }
        //For VehicleManufacturer for vehicleReport
        [Required(ErrorMessage = "Field Required!")]
        public string VehicleManufacture { get; set; }
        // ForDistinguish Report is 15, 7 days, Monthly and Yearly
        [Required(ErrorMessage = "Field Required!")]
        public string ReportDurationType { get; set; }
        [Required(ErrorMessage = "Field Required!")]

        public int CompanyId { get; set; }
        [Required(ErrorMessage = "Field Required!")]
        public IEnumerable<Users> DriverList { get; set; }

        //For Driver Category Use in ViewModel for Driver Report
        //For Vehicle Type for vehicleReport
    }
}