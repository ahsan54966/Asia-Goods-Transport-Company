using Fyp_First_Increment.Models;
using Fyp_First_Increment.ViewModel.Home;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Fyp_First_Increment.Controllers
{
    [AllowAnonymous]
//    [Fyp_First_Increment.MvcApplication.NoDirectAccess]
    public class RegistrationController : Controller
    {
        // GET: Registration

       //here is picture method called in customer,admin and driver
        public Models.Companydetail PictureSave(Companydetail Reg)
        {
            if(Reg.image_file.FileName!="")
            {
                string filename = Path.GetFileNameWithoutExtension(Reg.image_file.FileName);
                string extension = Path.GetExtension(Reg.image_file.FileName).ToLower();
                if (extension == ".jpg" || extension == ".png") //check file type
                {
                    filename = filename + DateTime.Now.ToString("yymmssfff") + extension;
                    Reg.Image = "~/Pictures/Registeration/" + filename;
                    filename = Path.Combine(Server.MapPath("~/Pictures/Registeration/"), filename);
                    Reg.image_file.SaveAs(filename);
                    TempData["UserData"] = Reg;
                }
                else
                {
                    TempData["extensionerror"] = "Plz check Your Image Type";

                }
            }

            return Reg;
        
        }

        //send mail method are call in customer,driver,admin
        public ActionResult sendmail()
        {

            string numbers = "0123456789";
            Random objrandom = new Random();
            string strrandom = string.Empty;
            for (int i = 0; i < 5; i++)
            {
                int temp = objrandom.Next(0, numbers.Length);
                strrandom += temp;
            }
            ViewBag.otp = strrandom;

            TempData["code"] = strrandom;

            TempData.Keep();

            Companydetail verifiedUser = TempData["Userdata"] as Companydetail;
            //string ahsan = verifiedUser.UserFirstName;


            WebMail.Send(verifiedUser.UserEmail, "Well Come '" + verifiedUser.UserFirstName + "_" + verifiedUser.UserLastName + "'  Sindhu Online Transport Company", "Dear Sir,<br/> You are Register this mobile NO  :" + verifiedUser.User_PhoneNumber + "<br/><br/> Your are Register With Email  :" + verifiedUser.UserEmail + "<br/><br/>Your Verfy Code Is :" + strrandom
            , null, null, null, true, null, null, null, null, null, null);


            TempData.Keep();
            return RedirectToAction("VerfyCode", "Registration");

        }
          //the page goes to verfy code so here chek the code and submit the form
        public ActionResult FinalyCustomerRegister()
        {

            return View();
        }
        [HttpPost]
        public ActionResult FinalyCustomerRegister(Companydetail REG, string command1)
        {
          
           //firstly we check a code is npot equall
            string role= (TempData["RegistrationRole"].ToString()); 
            string C;
            if (TempData["code"] != null) //code recive in send mail method
            {
                C = (TempData["code"].ToString());  //code assign in varible c for if check

         
          if (REG.VerifyCode==C)                          //code match ,user enter
          {

                Companydetail verifiedUser = TempData["Userdata"] as Companydetail;   //tempdata user(user reg form) assign in veifieduser
                CustomerRegister cust_reg = new CustomerRegister();
                if (role == "Sing Up") //its for customer sing up
              {
                    cust_reg.Customer_register(verifiedUser);

                    //PictureSave(REG);
                    return RedirectToAction("Login", "Registration", new { id=Session["LoginId"]}); //user sucessfullly registered and goes customer home page
              }

                else if (role == "Register")// its for admin
              {
                  cust_reg.Admin_Register(verifiedUser);
                 // PictureSave(REG);
                  List<Companydetail> Reg = new List<Companydetail>();
                  Reg.Add(verifiedUser);
                  Session["UserData"] = Reg;

                  return RedirectToAction("Login", "Registration", new { id = Session["LoginId"] }); //user sucessfullly registered and goes  admin home page
              }


                else if (role == "Registered")
              {
                  //PictureSave(REG);
                  cust_reg.Driver_Register(verifiedUser);
                  return RedirectToAction("Login", "Registration", new { id = Session["LoginId"] }); //user sucessfullly registered and goes  admin home page
              }
                else if(role=="Reset Password")
              {
                  return RedirectToAction("UpdatePassword", "Registration", new { id=Session["LoginId"]}); //user sucessfullly registered and goes update  home page
              }

          }
          else
          {
              TempData["WrongCode"] = "Yor code is not verified <br/> Plz TRY Again"; //code is not verified
             
          }
            }
            else
            {
                TempData["Errormessage"] = "Enter your 5 digit code"; //code is not entered,
            }
            if (command1 == "Resend Code") //here is code is resend code and redirect to verify code page
            {

                string numbers = "0123456789";
                Random objrandom = new Random();
                string strrandom = string.Empty;
                for (int i = 0; i < 5; i++)
                {
                    int temp = objrandom.Next(0, numbers.Length);
                    strrandom += temp;
                }
                ViewBag.otp = strrandom;

                TempData["code"] = strrandom;
                TempData.Keep();
               
                Companydetail verifiedUser = TempData["Userdata"] as Companydetail;
                string ahsan = verifiedUser.UserFirstName;


                WebMail.Send(verifiedUser.UserEmail, "Well Come '" + verifiedUser.UserLastName + "_" + verifiedUser.UserLastName + "'  Sindhu Online Transport Company", "Dear Sir,<br/> You are Register this mobile NO  :" + verifiedUser.User_PhoneNumber + "<br/><br/> Your are Register With Email  :" + verifiedUser.UserEmail + "<br/><br/>Your Verfy Code Is :" + strrandom
                , null, null, null, true, null, null, null, null, null, null);


                TempData.Keep();
                TempData["ResendMessage"] = "Check Your Email You get 5 digit Verify Code"; //code is not entered,
                return RedirectToAction("VerfyCode", "Registration", new { id = Session["LoginId"] });

            }
          return RedirectToAction("VerfyCode", "Registration");
        }


        //admin registration like as customer and driver

        public ActionResult AdminRegister()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdminRegister(Companydetail Reg,string command)
        {
            if (command == "Register")
            {
                ModelState["PinCode"].Errors.Clear();
                ModelState["VehicleNumber"].Errors.Clear();
                if (ModelState.IsValid)
                {
                    CustomerRegister Admin = new CustomerRegister();

                   

                string userexist= Admin.register(Reg);

       
                   if (userexist=="0")
                   {
                       TempData["Erroruserexist"] = "User is already exist ,Plz login";
                       return RedirectToAction("AdminRegister", "Registration");
                   }
                   else
                   {
                       PictureSave(Reg);
                       if (TempData["extensionerror"] == null)
                       {
                           TempData["RegistrationRole"] = command;
                           TempData.Keep();
                           sendmail();
                            return RedirectToAction("VerfyCode", "Registration");
                       }

                       else
                       {
                           return RedirectToAction("AdminRegister", "Registration");
                       } 
                   }
                }


            }
            return View();
        }


        //here is start login we get id as from button
        public ActionResult Login(int id=0)
        {
            Session["LoginId"] = id;
              return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Companydetail log, int id)
        {
//            
            if ((ModelState.IsValidField("User_PhoneNumber") && ModelState.IsValidField("User_Password")) || (ModelState.IsValidField("VehicleNumber") && ModelState.IsValidField("PinCode")))
            {
                string username = "";
                int f_key = id; //here we get forgin key and 

                CustomerRegister login = new CustomerRegister();

                if (id == 2)
                {
                    Session["VehicleNumber"] = login.VehicleLogin(log);
                    var userdata = (List<Companydetail>)Session["VehicleNumber"];
                    foreach (var s in userdata as List<Companydetail>)
                    {
                        username = s.VehicleNumber;

                    }

                }
                else
                {
                    //TempData["Userdata"] = login.userlogin(log, f_key);
                    List<Companydetail> Reg = login.userlogin(log, f_key);
                    TempData.Keep();
                    Session["UserData"] = Reg;
                    var userdata = (List<Companydetail>)Session["Userdata"];
                    foreach (var s in userdata as List<Companydetail>)
                    {
                        username = s.UserFirstName;

                    }
                }






                if (username != null)
                {
                    //Session["loginuser"] = userdata.user_first_name;


                    //if (Session["loginuser"] != "")
                    //{
                    //here cheked id we recive in button and redirect with specfic id
                    if (id == 1)
                    {

                        return RedirectToAction("Index", "Admin");

                    }
                    if (id == 4)
                    {
                        //Session["user"] =userdata.user_first_name;
                        return RedirectToAction("Index", "Customer");

                    }
                    if (id == 2)
                    { //its goes to driver/vehicle index page
                        //Session["user"] =userdata.user_first_name;
                        return RedirectToAction("Index", "Vehicle");

                    }
                }
                else
                {
                    TempData["message"] = "Login failed Try Again";
                }


            }

                return View();


           
        }
        //its page form action is finalregistration method
        public ActionResult VerfyCode()
        {

            //if (Session["user"] == null)
            //{
            //    return RedirectToAction("Login");
            //}

            return View();
        }
        //firstly check user is exist then alow to reset password
        public ActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ForgetPassword(Companydetail Reg,string command)
        {
            if (ModelState.IsValidField("UserEmail"))
            {
                CustomerRegister cust_reg = new CustomerRegister();
                if (command == "Reset Password")
                {
                    TempData["UserData"] = cust_reg.forgetpassword(Reg);


                    Companydetail CheckedUser = TempData["Userdata"] as Companydetail;
                    string phone = CheckedUser.User_PhoneNumber;
                    TempData["Phone"] = phone;
                    if (phone == null) //dont get valu data base show error message
                    {

                        TempData["Error"] = "User is Not exist Plz Try Again";
                        return RedirectToAction("ForgetPassword", "Registration");

                    }
                    else //if user is valid then send code and redirect in verify code
                    {
                        TempData["RegistrationRole"] = command;
                        TempData.Keep();
                        sendmail();
                        return RedirectToAction("VerfyCode", "Registration", new { id = Session["LoginId"] });   
                    }
                }
            }
            return View();
        }

        //here is update password and goes to login
        public ActionResult UpdatePassword()
        {
            TempData.Keep();
            return View();
        }
    [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdatePassword(Companydetail Reg,string user_ph)
        {

            user_ph= (TempData["Phone"].ToString()); 
            CustomerRegister cust_reg = new CustomerRegister();
            string check=cust_reg.UpdatePassword(Reg,user_ph);
            if(check=="1")
            {
                TempData["updatemessage"] = "Password Updated Successfully";
            }
            else
            {
                TempData["updatemessage"] = "Problem";
            }

            return RedirectToAction("Login", "Registration", new { id=Session["LoginId"]});   
        }
    public ActionResult Logout(int id=0)
    {
        Session.RemoveAll();
        return RedirectToAction("Index", "Home");
            
    }


    }
}