using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fyp_First_Increment.Models;
using System.ComponentModel.DataAnnotations;
namespace Fyp_First_Increment.ViewModel.Admin
{
    public class RideViewModel
    {
        public int RideId { get; set; }
        [Required(ErrorMessage = "Field Required!")]
        [RegularExpression(@"^[a-zA-Z,!? ]*$", ErrorMessage = "Enter Source In Correct Form,Only Alphabets")]
        public string RideSource { get; set; }
        [Required(ErrorMessage = "Field Required!")]
        [RegularExpression(@"^[a-zA-Z,!? ]*$", ErrorMessage = "Enter Destination In Correct Form,Only Alphabets")]
        public string RideDestination { get; set; }
        [Required(ErrorMessage = "Field Required!")]
        public int? RideDieselExpense { get; set; }
        [Required(ErrorMessage = "Field Required!")]
        public int? RideMaintainanceExpense { get; set; }
        [Required(ErrorMessage = "Field Required!")]
        public int? RideFoodExpense { get; set; }
        [Required(ErrorMessage = "Field Required!")]
        public int? RideMobileExpense { get; set; }
        [Required(ErrorMessage = "Field Required!")]
        public int? RideTaxExpense { get; set; }
        [Required(ErrorMessage = "Field Required!")]
        public int? RideDriverCharge { get; set; }
        [Required(ErrorMessage = "Field Required!")]
        public int? RideCommisionCharge { get; set; }
        [Required(ErrorMessage = "Field Required!")]
        public string RideDieselQuantity { get; set; }
        [Required(ErrorMessage = "Field Required!")]
        public int RideDriverId { get; set; }
        [Required(ErrorMessage = "Field Required!")]
        public string RideVehicleNumber { get; set; }
        [Required(ErrorMessage = "Field Required!")]
        public int? RideProdit { get; set; }
         [Required(ErrorMessage = "Field Required!")]
        public Ride Ride { get; set; }
        [Required(ErrorMessage = "Field Required!")]
        public string RideSeller { get; set; }
        [Required(ErrorMessage = "Field Required!")]
        public string RideBuyer { get; set; }
        [Required(ErrorMessage = "Field Required!")]
        public int? RideFare { get; set; }
        [Required(ErrorMessage = "Field Required!")]
        public string RideDetail { get; set; }
        [Required(ErrorMessage = "Field Required!")]
        //[DisplayFormat(DataFormatString = "{d}")]
        public DateTime RideDate { get; set; }
        [Required(ErrorMessage = "Field Required!")]
        public int? RidePassengers { get; set; }
        [Required(ErrorMessage = "Field Required!")]
        public int? RidePassengerFare { get; set; }
        [Required(ErrorMessage = "Field Required!")]
        public string RideType { get; set; }
        [RegularExpression(@"[a-zA-Z][a-zA-Z ]+", ErrorMessage = "Enter Cundoctor Name In Correct Form")]
        public string RideConductorName { get; set; }
        public int CompanyId { get; set; }
        public IEnumerable<Users> Drivers { get; set; }



        public RideViewModel()
        {
            RideId = 0;
        }
        public RideViewModel(Ride ride)
    {
            RideId = ride.RideId;
            RideSource=ride.RideSource;
            RideDestination =ride.RideDestination;
            RideDieselExpense =ride.RideDieselExpense;
            RideMaintainanceExpense =ride.RideMaintainanceExpense;
            RideFoodExpense =ride.RideFoodExpense;
            RideMobileExpense=ride.RideMobileExpense;
            RideTaxExpense =ride.RideTaxExpense;
            RideDriverCharge =ride.RideDriverCharge;
            RideCommisionCharge=ride.RideCommisionCharge;
            RideDieselQuantity=ride.RideDieselQuantity;
            RideDriverId=ride.RideDriverId;
            RideVehicleNumber =ride.RideVehicleNumber;
            RideProdit=ride.RideProdit;
            RideSeller=ride.RideSeller;
            RideBuyer=ride.RideBuyer;
            RideFare =ride.RideFare;
            RideDetail =ride.RideDetail;
            RideDate = ride.RideDate;
            RidePassengerFare = ride.RidePassengerFare;
            RidePassengers = ride.RidePassengers;
            RideConductorName = ride.RideConductorName;
            RideType = ride.RideType;
    }


    }
}