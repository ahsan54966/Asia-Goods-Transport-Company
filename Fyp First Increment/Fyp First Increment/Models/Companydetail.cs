using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Fyp_First_Increment.Models
{
    public class Companydetail :Users
    {

        //company table parameter
        //no view
        [MinLength(13, ErrorMessage = "Enter Valid Length")]
        [MaxLength(13, ErrorMessage = "Enter Valid Length")]
        [Required(ErrorMessage="Please Enter Company NTN")]
        [RegularExpression(@"^[0-9\-]{13}$", ErrorMessage = "Enter Valid Data")]
         public string Comp_Reg_No { get; set; }




        [Required(ErrorMessage = "Enter Name")]
        [RegularExpression(@"[a-zA-Z][a-zA-Z ]+", ErrorMessage = "Please Enter Valid Name")]
        [MinLength(4)]
        [MaxLength(15)]
        public string Comp__owner_name { get; set; }




        [Required(ErrorMessage = "Enter CNIC")]
        [RegularExpression(@"^[0-9\-]{13}$", ErrorMessage = "Enter CNIC Number in Valid Form")]
        [MinLength(13)]
        [MaxLength(13)]
        public string owner_cnic { get; set; }




        [DataType(DataType.PhoneNumber, ErrorMessage = "Enter Valid Number")]
         [MinLength(11, ErrorMessage = "Enter Valid Phone Number Length")]
        [MaxLength(11, ErrorMessage = "Enter Valid Phone Number Length")]
        [RegularExpression(@"^03[0-9]{9}$", ErrorMessage = "Enter Valid Phone Number")]
        public string owner_ph { get; set; }




        [Required(ErrorMessage = "Enter Company Worth")]
        [RegularExpression(@"^[a-zA-Z0-9]+(\s[a-zA-Z0-9]+)?$", ErrorMessage = "Enter Company Worth")]
        [MinLength(3, ErrorMessage = "Enter Valid Length")]
        [MaxLength(10, ErrorMessage = "Enter Valid Length")]
        public string comp_worth { get; set; }





        [MinLength(3, ErrorMessage = "Enter Valid Length")]
        [MaxLength(70, ErrorMessage = "Enter Valid Length")]
        [Required(ErrorMessage = "Enter Address")]
        public string comp_adress { get; set; }




        [Required(ErrorMessage = "Enter Vehicles Quantity")]
        [RegularExpression(@"^[a-zA-Z0-9]+(\s[a-zA-Z0-9]+)?$", ErrorMessage = "Enter Valid No of Vehicles")]
        [MinLength(1)]
        [MaxLength(20)]
        public string comp_no_vehicle { get; set; }
    }
}