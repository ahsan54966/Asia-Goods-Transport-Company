using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fyp_First_Increment.Models
{
    public class Builty
    {

        public int BuiltyId { get; set; }

        [MinLength(4)]
        [MaxLength(50,ErrorMessage="Enter valid Length")]
        [Required(ErrorMessage = "Field Required!")]
        [RegularExpression(@"^[a-zA-Z,!? ]*$", ErrorMessage = "Only Alphabets,Space and comma Allow")]
        public string BuiltySource { get; set; }


        [MinLength(4)]
        [MaxLength(50, ErrorMessage = "Enter valid Length")]
        [Required(ErrorMessage = "Field Required!")]
        [RegularExpression(@"^[a-zA-Z,!? ]*$", ErrorMessage = "Only Alphabets,Space and comma Allow")]
        public string BuiltyDestination { get; set; }

/*

        [Required(ErrorMessage = "Selcet Driver !")]
        public int BuiltyDriverId { get; set; }*/



        [Required(ErrorMessage = "Select Vehicle Number!")]
        public string BuiltyVehicleNumber { get; set; }




        [Required(ErrorMessage = "Enter Seller Name")]
        [RegularExpression(@"[a-zA-Z][a-zA-Z ]+", ErrorMessage = "Only Latters and Space Allowed")]
        [MinLength(3)]
        [MaxLength(15)]
        public string BuiltySeller { get; set; }



        [Required(ErrorMessage = "Enter Buyer Name")]
        [RegularExpression(@"[a-zA-Z][a-zA-Z ]+$", ErrorMessage = "Only Latters and Space Allowed")]
        [MinLength(3)]
        [MaxLength(15)]
        public string BuiltyBuyer { get; set; }



        [Required(ErrorMessage = "Enter Driver Name")]
        [RegularExpression(@"[a-zA-Z][a-zA-Z ]+$", ErrorMessage = "Only Latters and Space Allowed")]
        [MinLength(3)]
        [MaxLength(15)]
        public string DriverName { get; set; }

        //It's works for 03462304003
        [DataType(DataType.PhoneNumber, ErrorMessage = "Not a number")]
        [Required(ErrorMessage = "Enter Mobile Number ")]
        [MinLength(11, ErrorMessage = "Enter Valid Phone Number Length")]
        [MaxLength(11, ErrorMessage = "Enter Valid Phone Number Length")]
        [RegularExpression(@"^03[0-9]{9}$", ErrorMessage = "Enter Valid Phone Number")]

        public string DriverPhoneNumber { get; set; }

        [Required(ErrorMessage = "Enter Builty Detail")]
        /*
         *[RegularExpression(@"^[a-zA-Z]+(\s[a-zA-Z]+)?$", ErrorMessage = "Only Latters and Space Allowed")]
        [MinLength(4)]
        [MaxLength(15)]
         * */
        public string BuiltyDetail { get; set; }




        [Required(ErrorMessage = "Select Vehicle Size")]
        //[RegularExpression(@"^[a-zA-Z0-9]?$", ErrorMessage = "Select Vehicle size")]
        public string VehicleSize { get; set; }


        [Required(ErrorMessage = "Enter Weight!")]
        [RegularExpression(@"^[a-zA-Z0-9]+(\s[a-zA-Z0-9]+)?$", ErrorMessage = "Enter Weight.. i.e 30  Ton")]
        [MinLength(3)]
        [MaxLength(20)]
        public string BuiltyWeight { get; set; }





        [Required(ErrorMessage = "Enter Goods Quantaty!")]
        [RegularExpression(@"^[a-zA-Z0-9]+(\s[a-zA-Z0-9]+)?$", ErrorMessage = "Only AlphaNumeric Allowed with Maximum 9 length")]
        [MinLength(3, ErrorMessage = "Enter Valid Length")]
        [MaxLength(20,ErrorMessage="Enter Valid Length")]
        public string BuiltyGoodsQuantaty { get; set; }

        /*

                [Required(ErrorMessage = "Enter Builty Fare!")]
                [RegularExpression(@"^[1-9][0-9]{1,5}$", ErrorMessage = "Only Numbers Allowed with 6 length")]
                public int? BuiltyFare { get; set; }



        //        [Required(ErrorMessage = "Enter Total Fare!")]
        //        [RegularExpression(@"^[1-9][0-9]{1,5}$", ErrorMessage = "Only Numbers Allowed with 6 length")]
                public int? BuiltyTotalFare { get; set; }



                [Required(ErrorMessage = "Enter Worker Charges!")]
                [RegularExpression(@"^[1-9][0-9]{1,5}$", ErrorMessage = "Only Numbers Allowed with 6 length")]
                public int? BuiltyWorkerCharge { get; set; }



                [Required(ErrorMessage = "Enter Builty Miscellaneous!")]
                [RegularExpression(@"^[1-9][0-9]{1,5}$", ErrorMessage = "Only Numbers Allowed with 6 length")]
                public int? BuiltyMiscellaneous { get; set; }
         * 
         * 
         * 
                [Required(ErrorMessage = "Select Arival Time ")]
                //[DisplayFormat(DataFormatString = "{d}")]
                public TimeSpan ArivalTime { get; set; }




                [Required(ErrorMessage = "Select Departur Time")]
                //[DisplayFormat(DataFormatString = "{d}")]
                public TimeSpan DeparturTime { get; set; }



                [Required(ErrorMessage = "Enter Builty Advance Payment!")]
                [RegularExpression(@"^[1-9][0-9]{1,5}$", ErrorMessage = "Only Numbers Allowed with 6 length")]
                public int? AdvancePayment { get; set; }

                */



        [Required(ErrorMessage = "Select Builty Date !")]
        //[DisplayFormat(DataFormatString = "{d}")]
        public DateTime BuiltyDate { get; set; }



        public int CompanyId { get; set; }


        public List<string> BuiltyDetailList { get; set; }
    }
}