using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fyp_First_Increment.Models
{
    public class Ride
    {
        public int RideId { get; set; }

        [MinLength(4)]
        [MaxLength(30)]
        [Required(ErrorMessage = "Field Required!")]
        [RegularExpression(@"^[a-zA-Z,!? ]*$", ErrorMessage = "Only Alphabets,Space and comma Allow")]
        public string RideSource { get; set; }

        [MinLength(4)]
        [MaxLength(30)]
        [RegularExpression(@"^[a-zA-Z,!? ]*$", ErrorMessage = "Only Alphabets,Space and comma Allow")]
        [Required(ErrorMessage = "Selec Ride Destination !")]
        public string RideDestination { get; set; }



        [Required(ErrorMessage = "Enter Desiel Expences!")]
        [RegularExpression(@"^[1-9][0-9]{1,5}$", ErrorMessage = "Only Numbers Allowed with 6 length")]
        public int? RideDieselExpense { get; set; }



        [Required(ErrorMessage = "Enter Maintainance Expences!")]
        [RegularExpression(@"^[1-9][0-9]{1,5}$", ErrorMessage = "Only Numbers Allowed with 6 length")]
        public int? RideMaintainanceExpense { get; set; }



        [Required(ErrorMessage = "Enter Ride Food Expences!")]
        [RegularExpression(@"^[1-9][0-9]{1,5}$", ErrorMessage = "Only Numbers Allowed with 6 length")]
        public int? RideFoodExpense { get; set; }



        [Required(ErrorMessage = "Enter Ride mobile Expences!")]
        [RegularExpression(@"^[1-9][0-9]{1,5}$", ErrorMessage = "Only Numbers Allowed with 6 length")]
        public int? RideMobileExpense { get; set; }



        [Required(ErrorMessage = "Enter Ride Tex Expences!")]
        [RegularExpression(@"^[1-9][0-9]{1,5}$", ErrorMessage = "Only Numbers Allowed with 6 length")]
        public int? RideTaxExpense { get; set; }



        [Required(ErrorMessage = "Enter Driver Charges!")]
        [RegularExpression(@"^[1-9][0-9]{1,5}$", ErrorMessage = "Only Numbers Allowed with 6 length")]
        public int? RideDriverCharge { get; set; }


        [Required(ErrorMessage = "Enter Ride Commission!")]
        [RegularExpression(@"^[1-9][0-9]{1,5}$", ErrorMessage = "Only Numbers Allowed with 6 length")]
        public int? RideCommisionCharge { get; set; }


        [Required(ErrorMessage = "Enter Desiel Quantity!")]
        [RegularExpression(@"^[1-9][0-9]{1,5}$", ErrorMessage = "Only Numbers Allowed with 6 length")]
        public string RideDieselQuantity { get; set; }
        
        
        [Required(ErrorMessage = "Selcet Driver !")]
        public int RideDriverId { get; set; }
        
        
        [Required(ErrorMessage = "Select Vehicle Number!")]
        public string RideVehicleNumber { get; set; }
        
        
        [Required(ErrorMessage = "Field Required!")]
        public int? RideProdit { get; set; }



        [Required(ErrorMessage = "Enter Seller Name")]
        [RegularExpression(@"[a-zA-Z][a-zA-Z ]+", ErrorMessage = "Only Letters and Space Allowed")]
        [MinLength(4)]
        [MaxLength(15)]
        public string RideSeller { get; set; }



        [Required(ErrorMessage = "Enter Buyer Name")]
        [RegularExpression(@"[a-zA-Z][a-zA-Z ]+$", ErrorMessage = "Only Latters and Space Allowed")]
        [MinLength(4)]
        [MaxLength(15)]
        public string RideBuyer { get; set; }
        
        

        [Required(ErrorMessage = "Enter Ride Fare!")]
        [RegularExpression(@"^[1-9][0-9]{1,5}$", ErrorMessage = "Only Numbers Allowed with 6 length")]
        public int? RideFare { get; set; }
        
        
        [Required(ErrorMessage = "Select Ride Date !")]
        //[DisplayFormat(DataFormatString = "{d}")]
        public DateTime RideDate { get; set; }


        [Required(ErrorMessage = "Enter Ride Detail")]
        [RegularExpression(@"^[a-zA-Z]+(\s[a-zA-Z]+)?$", ErrorMessage = "Only Latters and Space Allowed")]
        [MinLength(4)]
        [MaxLength(15)]
        public string RideDetail { get; set; }
        
        
        [Required(ErrorMessage = "Enter Number of Passangers!")]
        [RegularExpression(@"^[1-9][0-9]{1,3}$", ErrorMessage = "Only Numbers Allowed with 6 length")]
        public int? RidePassengers { get; set; }
        
        
        [Required(ErrorMessage = "Enter Ride Passanger Fare!")]
        [RegularExpression(@"^[1-9][0-9]{1,5}$", ErrorMessage = "Only Numbers Allowed with 6 length")]
        public int? RidePassengerFare  { get; set; }


        [Required(ErrorMessage = "Enter Conductor Name")]
        [RegularExpression(@"[a-zA-Z][a-zA-Z ]+", ErrorMessage = "Enter Cundoctor Name In Correct Form")]
        [MinLength(2)]
        [MaxLength(15)]
        public string RideConductorName { get; set; }
        
        
        [Required(ErrorMessage = "Field Required!")]
        public string RideType { get; set; }
        public int CompanyId { get; set; }
    }
}