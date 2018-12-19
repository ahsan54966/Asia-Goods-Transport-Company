using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Fyp_First_Increment.Models
{
    public class Users
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "Enter First Name")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Enter First Name In Correct Form")]
        [MinLength(2)]
        [MaxLength(15)]


        public string UserFirstName { get; set; }
        [Required(ErrorMessage = "Enter Last Name")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Enter Last Name In Correct Form")]
        [MinLength(2)]
        [MaxLength(15)]
        public string UserLastName { get; set; }



        //It's works for 03462304003
        [DataType(DataType.PhoneNumber, ErrorMessage = "Not a number")]
        [Required(ErrorMessage = "Enter Mobile Number ")]
        [MinLength(11, ErrorMessage = "Enter Valid Phone Number Length")]
        [MaxLength(11, ErrorMessage = "Enter Valid Phone Number Length")]
        [RegularExpression(@"^03[0-9]{9}$", ErrorMessage = "Enter Valid Phone Number")]
       
        public string User_PhoneNumber { get; set; }



        [Required(ErrorMessage = "Enter Email")]
        [MinLength(10, ErrorMessage = "Enter Valid Email Length")]
        [MaxLength(30, ErrorMessage = "Enter Valid Email Length")]
        [RegularExpression(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$", ErrorMessage = "Enter Correct Email Address")]
        public string UserEmail { get; set; }



        [Required(ErrorMessage = "Enter CNIC")]
        [RegularExpression(@"^[0-9\-]{13}$", ErrorMessage = "Enter CNIC Number in Valid Form")]
        [MinLength(13)]
        [MaxLength(13)]

        public string UserCnic { get; set; }



        [Required(ErrorMessage = "Enter City")]
        [RegularExpression(@"^[a-zA-Z]+(\s[a-zA-Z]+)?$", ErrorMessage = "Only Latters and Space Allowed")]
        [MinLength(4)]
        [MaxLength(15)]
        public string user_City { get; set; }



        [Required(ErrorMessage = "Enter User Address ")]
        //[RegularExpression(@"^[A-Za-z0-9'\.\-\s\,]", ErrorMessage = "Enter Address in Valid Form")]
        [MinLength(5)]
        [MaxLength(50)]
        public string UserAddress { get; set; }



        [Required(ErrorMessage = "Enter Password")]
        [RegularExpression(@"^^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,14}$", ErrorMessage = "Password should contain one capital letter and a number atleast")]
        [MinLength(6)]
        [MaxLength(14)]
        public String User_Password { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Confirm Password required")]
        [CompareAttribute("User_Password", ErrorMessage = "Password doesn't match.")]
        [MinLength(6)]
        [MaxLength(14)]
        public string ConfirmPassowrd { get; set; }



        [Required(ErrorMessage = "Enter User Company")]
        [RegularExpression(@"[a-zA-Z][a-zA-Z ]+", ErrorMessage = "Only Latters and Space Allowed")]
        [MinLength(4)]
        [MaxLength(60)]
        public string user_comp { get; set; }



        [Required(ErrorMessage = "Enter Company Type")]
        [RegularExpression(@"[a-zA-Z][a-zA-Z ]+", ErrorMessage = "Only Latters and Space Allowed")]
        [MinLength(2)]
        [MaxLength(15)]
        public string user_comp_type { get; set; }
      
        
        //forign key Role Table
        public int UserRoleId { get; set; }


        public string Image { get; set; }



        [Required(ErrorMessage = "Upload Image")]
        public HttpPostedFileBase image_file { get; set; }

//        Resend Code dont work if Required applied
//        [Required(ErrorMessage = "Enter Verification Code")]
        public string VerifyCode { get; set; }



        [DataType(DataType.PhoneNumber, ErrorMessage = "Not a number")]
        [Required(ErrorMessage = "Enter Mobile Number ")]
        [MinLength(11, ErrorMessage = "Enter Valid Phone Number Length")]
        [MaxLength(11, ErrorMessage = "Enter Valid Phone Number Length")]
        [RegularExpression(@"^03[0-9]{9}$", ErrorMessage = "Enter Valid Phone Number")]
        public string CompanyPhoneNumber { get; set; }


        // For Login Page of vehicle^
        [Required(ErrorMessage="Required")]
        public string VehicleNumber { get; set; }
        [Required(ErrorMessage="Pin Code Required")]
        public string PinCode { get; set; }
    }
}