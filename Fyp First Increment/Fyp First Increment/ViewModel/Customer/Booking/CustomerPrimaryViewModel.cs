using Fyp_First_Increment.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fyp_First_Increment.ViewModel.Customer.Booking
{
    public class CustomerPrimaryViewModel
    {
        public int BookingId { get; set; }
        
        [Required(ErrorMessage = "Enter Booking Source")]
        /*
        [RegularExpression(@"^[a-zA-Z,!? ]*$", ErrorMessage = "Enter Source In Correct Form,Only Alphabets")]
        [MinLength(3)]
        [MaxLength(35)]
         */
        public string BookingSource { get; set; }
        


        [Required(ErrorMessage = "Enter Booking Destination")]
        /*
        [RegularExpression(@"^[a-zA-Z,!? ]*$", ErrorMessage = "Enter Destination In Correct Form,Only Alphabets")]
        [MinLength(3)]
        [MaxLength(35)]
         * */
        public string BookingDestination { get; set; }
        


        [Required(ErrorMessage = "Enter Goods Detail")]
        /*
        [RegularExpression(@"^[a-zA-Z]+(\s[a-zA-Z]+)?$", ErrorMessage = "Only Latters and Space Allowed")]
        [MinLength(3)]
        [MaxLength(35)]
         */
        public string BookingGoodsDetail { get; set; }



        [Required(ErrorMessage = "Enter Quantity Detail")]
        /*
        [RegularExpression(@"^[a-zA-Z0-9]+(\s[a-zA-Z0-9]+)?$", ErrorMessage = "Enter Quantity.. i.e 300  Bag")]
        [MinLength(3)]
        [MaxLength(20)]
         * */
        public string BookingQunatity { get; set; }



        [Required(ErrorMessage = "Enter Weight")]
        /*
        [RegularExpression(@"^[a-zA-Z0-9]+(\s[a-zA-Z0-9]+)?$", ErrorMessage = "Enter Weight.. i.e 30  Ton")]
        [MinLength(3)]
        [MaxLength(20)]
         */
        public string BookingWeight { get; set; }



        [Required(ErrorMessage = "Enter Booking Fare ")]
        /*
        [RegularExpression(@"^([0-9])[0-9]*[.]?[0-9]{1,6}$", ErrorMessage = "Only Numbers Allowed")]
        [MinLength(1)]
        [MaxLength(6)]
         */
        public string BookingFare { get; set; }
        [Required(ErrorMessage = "Required!")]
        public DateTime BookingDate { get; set; }
        [Required(ErrorMessage = "Required!")]
        public DateTime BookingRequestDate { get; set; }
        [Required(ErrorMessage = "Required!")]
        public string BookingTimeArrival { get; set; }
        [Required(ErrorMessage = "Required!")]
        public int BookingCustomerId { get; set; }
        [Required(ErrorMessage = "Required!")]
        public string BookingPhoneNumber { get; set; }
        public string BookingStatus { get; set; }
        [Required(ErrorMessage = "Required!")]
        public string BookingServiceType { get; set; }
        [Required(ErrorMessage = "Required!")]
        public string BookingMaterialType { get; set; }
        [Required(ErrorMessage = "Required!")]
        public string BookingVehicleType { get; set; }
        public string BookingSourceLat { get; set; }
        public string BookingSourceLon { get; set; }
        public string BookingDestinationLat { get; set; }
        public string BookingDestinationLon { get; set; }
    }
}