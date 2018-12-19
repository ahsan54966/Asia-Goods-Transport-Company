using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Fyp_First_Increment.Models;
using System.Configuration;
using System.Text;
namespace Fyp_First_Increment.ViewModel.Home
{
    public class CustomerRegister
    { //here is user verified user valid or not
        public string register(Companydetail Reg)
        {
            string message = "";
            string connection = ConfigurationManager.ConnectionStrings["temp_transport"].ConnectionString;
            
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                using (SqlCommand cm = new SqlCommand("validuser", con))
                {
                    cm.CommandType = System.Data.CommandType.StoredProcedure;


                    cm.Parameters.AddWithValue("@User_PhoneNumber", Reg.User_PhoneNumber);
                    cm.Parameters.AddWithValue("@User_Email", Reg.UserEmail);



                    SqlDataReader dr = cm.ExecuteReader();
                    if (dr.Read())
                    {
                        //Reg.error = "Sorry this user is already exist";
                        message = "0";
                    }
                    else
                    {

                        message = "1";

                        //     con.Close();

                    }


                }
                return message;
            }

        }

        //here after verify user save in database also forgin key store
        public string Admin_Register(Companydetail verifiedUser)
        {
            //encrypted password
            string enc = verifiedUser.User_Password;
            byte[] encode = new byte[enc.Length];
            encode = Encoding.UTF8.GetBytes(verifiedUser.User_Password);
            string enc_password = Convert.ToBase64String(encode);


            string user_id = "";
            string connection = ConfigurationManager.ConnectionStrings["temp_transport"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connection))
            {


                con.Open();
                using (SqlCommand cmd = new SqlCommand("Admin_Registration", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@User_FirstName", verifiedUser.UserFirstName);
                    cmd.Parameters.AddWithValue("@User_LastName", verifiedUser.UserLastName);
                    cmd.Parameters.AddWithValue("@User_PhoneNumber", verifiedUser.User_PhoneNumber);
                    cmd.Parameters.AddWithValue("@User_Address", verifiedUser.UserAddress);
                    cmd.Parameters.AddWithValue("@User_Cnic", verifiedUser.UserCnic);
                    cmd.Parameters.AddWithValue("@User_Email", verifiedUser.UserEmail);
                    cmd.Parameters.AddWithValue("@User_Password", enc_password);
                    cmd.Parameters.AddWithValue("@User_Role_Id", 1);
                    cmd.Parameters.AddWithValue("@User_Image", verifiedUser.Image);
                    cmd.Parameters.AddWithValue("@CompanyName", verifiedUser.user_comp);
                    cmd.Parameters.AddWithValue("@CompanyType", verifiedUser.user_comp_type);
                    cmd.Parameters.AddWithValue("@UserCity", verifiedUser.user_City);


                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {

                        verifiedUser.UserId = int.Parse(dr["UserId"].ToString());



                    }
                    //company detail
                    con.Close();
                    con.Open();
                    using (SqlCommand cm = new SqlCommand("Company_info", con))
                    {
                        cm.CommandType = System.Data.CommandType.StoredProcedure;

                        cm.Parameters.AddWithValue("@CompanyRegNum", verifiedUser.Comp_Reg_No);
                        cm.Parameters.AddWithValue("@CompanyOwner", verifiedUser.Comp__owner_name);
                        //cm.Parameters.AddWithValue("@owner_cnic", verifiedUser.owner_cnic);
                        //cm.Parameters.AddWithValue("@owner_ph", verifiedUser.owner_ph);
                        cm.Parameters.AddWithValue("@CompanyVehicleQuanitity", verifiedUser.comp_no_vehicle);
                        cm.Parameters.AddWithValue("@CompanyWorth", verifiedUser.comp_worth);
                        cm.Parameters.AddWithValue("@CompanyAddress", verifiedUser.comp_adress);
                        cm.Parameters.AddWithValue("@CompanyPhoneNumber", verifiedUser.CompanyPhoneNumber);
                        cm.Parameters.AddWithValue("@CompanyUserId", verifiedUser.UserId);
                        cm.ExecuteNonQuery();
                        con.Close();
                        return user_id;
                    }
                }
            }
        }

        //here after verify customer save in database also forgin key store
        public string Customer_register(Companydetail verifiedUser)
        {
            //encrypted password
            string enc = verifiedUser.User_Password;
            byte[] encode = new byte[enc.Length];
            encode = Encoding.UTF8.GetBytes(verifiedUser.User_Password);
            string enc_password = Convert.ToBase64String(encode);

            string message = "";
            string connection = ConfigurationManager.ConnectionStrings["temp_transport"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connection))
            {


                con.Open();
                using (SqlCommand cmd = new SqlCommand("User_Registration", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@User_FirstName", verifiedUser.UserFirstName);
                    cmd.Parameters.AddWithValue("@User_LastName", verifiedUser.UserLastName);
                    cmd.Parameters.AddWithValue("@User_PhoneNumber", verifiedUser.User_PhoneNumber);
                    cmd.Parameters.AddWithValue("@User_Address", verifiedUser.UserAddress);
                    cmd.Parameters.AddWithValue("@User_Cnic", verifiedUser.UserCnic);
                    cmd.Parameters.AddWithValue("@User_Email", verifiedUser.UserEmail);
                    cmd.Parameters.AddWithValue("@User_Password", enc_password);
                    cmd.Parameters.AddWithValue("@User_Role_Id", 4);
                    cmd.Parameters.AddWithValue("@User_Image", verifiedUser.Image);
                    cmd.Parameters.AddWithValue("@CompanyName", verifiedUser.user_comp);
                    cmd.Parameters.AddWithValue("@CompanyType", verifiedUser.user_comp_type);
                    cmd.Parameters.AddWithValue("@UserCity", verifiedUser.user_City);

                    cmd.ExecuteNonQuery();


                    con.Close();
                    message = "User sucessfully add";
                    return message;

                }
            }
        }

        //here after verify Driver save in database also forgin key store
        public string Driver_Register(Companydetail verifiedUser)
        {
            string user_id = "";
            string connection = ConfigurationManager.ConnectionStrings["temp_transport"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connection))
            {


                con.Open();
                using (SqlCommand cmd = new SqlCommand("Admin_Registration", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;


                    cmd.Parameters.AddWithValue("@User_FirstName", verifiedUser.UserFirstName);
                    cmd.Parameters.AddWithValue("@User_LastName", verifiedUser.UserLastName);
                    cmd.Parameters.AddWithValue("@User_PhoneNumber", verifiedUser.User_PhoneNumber);
                    cmd.Parameters.AddWithValue("@User_Address", verifiedUser.UserAddress);
                    cmd.Parameters.AddWithValue("@User_Cnic", verifiedUser.UserCnic);
                    cmd.Parameters.AddWithValue("@User_Email", verifiedUser.UserEmail);
                    cmd.Parameters.AddWithValue("@User_Password", verifiedUser.User_Password);
                    cmd.Parameters.AddWithValue("@User_Role_Id", 2);
                    cmd.Parameters.AddWithValue("@User_Image", verifiedUser.Image);
                    cmd.Parameters.AddWithValue("@CompanyName", verifiedUser.user_comp);
                    cmd.Parameters.AddWithValue("@CompanyType", verifiedUser.user_comp_type);
                    cmd.Parameters.AddWithValue("@UserCity", verifiedUser.user_City);


                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {

                        user_id = Convert.ToInt32(dr["UserId"]).ToString();



                    }
                    //company detail
                    con.Close();
                    con.Open();
                    using (SqlCommand cm = new SqlCommand("Driver_info", con))
                    {
                        //cm.CommandType = System.Data.CommandType.StoredProcedure;
                        //cm.Parameters.AddWithValue("@DriverSalary", verifiedUser.Driver_Salery);
                        //cm.Parameters.AddWithValue("@DriverExperience", verifiedUser.Dreiver_exprience);
                        //cm.Parameters.AddWithValue("@DriverType", verifiedUser.Driver_Type);
                        //cm.Parameters.AddWithValue("@DriverPosition", verifiedUser.Driver_position);
                        //cm.Parameters.AddWithValue("@DriverRouteCharge", verifiedUser.Driver_Routchaege);
                        cm.Parameters.AddWithValue("@DriverUserId", user_id);
                        cm.ExecuteNonQuery();
                        con.Close();

                        return user_id;
                    }
                }
            }

        }
        //here is forget password uwer exist or not it valid user check with email
        public Companydetail forgetpassword(Companydetail Reg)
        {

            string connection = ConfigurationManager.ConnectionStrings["temp_transport"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                using (SqlCommand cm = new SqlCommand("forgetpassword", con))
                {
                    cm.CommandType = System.Data.CommandType.StoredProcedure;



                    cm.Parameters.AddWithValue("@User_Email", Reg.UserEmail);


                    SqlDataReader dr = cm.ExecuteReader();
                    if (dr.Read())
                    {

                        Reg.UserFirstName = dr["User_FirstName"].ToString();
                        Reg.UserLastName = dr["User_LastName"].ToString();
                        Reg.User_PhoneNumber = dr["User_PhoneNumber"].ToString();

                    }
                    //else
                    //{
                    //}
                }
                return Reg;

            }
        }

        //here user reset password  
        public string UpdatePassword(Companydetail reg, string user_ph)
        {
            //encrypted password
            string enc = reg.User_Password;
            byte[] encode = new byte[enc.Length];
            encode = Encoding.UTF8.GetBytes(reg.User_Password);
            string enc_password = Convert.ToBase64String(encode);

            string message = "";
            string connection = ConfigurationManager.ConnectionStrings["temp_transport"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                using (SqlCommand cm = new SqlCommand("UpdatePassword", con))
                {
                    cm.CommandType = System.Data.CommandType.StoredProcedure;



                    cm.Parameters.AddWithValue("@User_Password", enc_password);
                    cm.Parameters.AddWithValue("@User_PhoneNumber", user_ph);




                    //SqlDataReader dr = cm.ExecuteReader();
                    if (cm.ExecuteNonQuery() > 0)
                    {
                        message = "1";

                    }
                    con.Close();
                }


                return message;


            }
        }

        public List<Companydetail> userlogin(Companydetail log, int f_key)
        {
            //encrypted password
            string enc = log.User_Password;
            byte[] encode = new byte[enc.Length];
            encode = Encoding.UTF8.GetBytes(log.User_Password);
            string enc_password = Convert.ToBase64String(encode);
            List<Companydetail> reglist = new List<Companydetail>();
            string connection = ConfigurationManager.ConnectionStrings["temp_transport"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                using (SqlCommand cm = new SqlCommand("Login", con))
                {
                    cm.CommandType = System.Data.CommandType.StoredProcedure;



                    cm.Parameters.AddWithValue("@User_PhoneNumber", log.User_PhoneNumber);

                    cm.Parameters.AddWithValue("@User_Password", enc_password);
                    cm.Parameters.AddWithValue("@f_key", f_key);

                    SqlDataReader dr = cm.ExecuteReader();
                    if (dr.Read())
                    {
                        log.UserFirstName = dr["User_FirstName"].ToString();
                        log.UserLastName = dr["User_LastName"].ToString();
                        log.UserId = int.Parse(dr["UserId"].ToString());
                        log.Image = dr["User_Image"].ToString();
                        log.user_comp = dr["CompanyName"].ToString();
                    }
                    //else
                    //{
                    //}
                }
                reglist.Add(log);
                return reglist;

            }
        }

        public List<Companydetail> VehicleLogin(Companydetail log)
        {

            List<Companydetail> reglist = new List<Companydetail>();

            string connection = ConfigurationManager.ConnectionStrings["temp_transport"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                using (SqlCommand cm = new SqlCommand("sp_Vehicle_VehicleLogin", con))
                {
                    cm.CommandType = System.Data.CommandType.StoredProcedure;



                    cm.Parameters.AddWithValue("@VehicleNumber", log.VehicleNumber);//vehicle no

                    cm.Parameters.AddWithValue("@PinCode", log.PinCode);//PinCode

                    Companydetail company = new Companydetail();
                    SqlDataReader dr = cm.ExecuteReader();
                    if (dr.Read())
                    {

                        company.Image = dr["Vehicle_ImageUrl"].ToString();
                        company.VehicleNumber = dr["Vehicle_Number"].ToString();
                        //here return vehicle no

                    }
                    //else
                    //{
                    //}
                    reglist.Add(company);
                }

                return reglist;
            }
        }


        public Users EditUser(int id)
        {
            Users user=new Users();
            string connection = ConfigurationManager.ConnectionStrings["temp_transport"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                using (SqlCommand cm = new SqlCommand("sp_User_EditUser", con))
                {
                    cm.CommandType = System.Data.CommandType.StoredProcedure;
                    cm.Parameters.AddWithValue("@UserId", id);

                    SqlDataReader dr = cm.ExecuteReader();
                    if (dr.Read())
                    {
                        user.UserFirstName = dr["User_FirstName"].ToString();
                        user.UserLastName = dr["User_LastName"].ToString();
                        user.UserAddress = dr["User_Address"].ToString();
                        user.User_Password = dr["User_Password"].ToString();
                        user.ConfirmPassowrd = dr["User_Password"].ToString();
                        user.Image = dr["User_Image"].ToString();
                        user.UserId =int.Parse(dr["UserId"].ToString());

                    }

                    //decrypted password
                    string dec = user.User_Password;
                    byte[] encodedDataAsBytes = System.Convert.FromBase64String(dec);
                    string dec_pass = System.Text.Encoding.UTF8.GetString(encodedDataAsBytes);
                    //else
                    //{
                    //}
                    user.User_Password = dec_pass;
                    user.ConfirmPassowrd = dec_pass;
                }
            }
                return user;
        }
        public string UpdateUser(Users user)
        {
            //encrypted password
            string enc = user.User_Password;
            byte[] encode = new byte[enc.Length];
            encode = Encoding.UTF8.GetBytes(user.User_Password);
            string enc_password = Convert.ToBase64String(encode);
            string message = "";
            string connection = ConfigurationManager.ConnectionStrings["temp_transport"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                using (SqlCommand cm = new SqlCommand("sp_User_UpdateUser", con))
                {
                    cm.CommandType = System.Data.CommandType.StoredProcedure;
                    cm.Parameters.AddWithValue("@User_FirstName", user.UserFirstName);
                    cm.Parameters.AddWithValue("@User_LastName", user.UserLastName);
                    cm.Parameters.AddWithValue("@User_Address", user.UserAddress);
                    cm.Parameters.AddWithValue("@UserId", user.UserId);
                    cm.Parameters.AddWithValue("@User_Password", enc_password);
                    cm.Parameters.AddWithValue("@User_Image", user.Image);
                    int check=cm.ExecuteNonQuery();
                    if (check>0)
                    {
                        message = "1";
                    }
                    else if(check==1)
                    {
                        message = "0";
                    }
                    else
                    {
                        throw new Exception("Database Problem");
                    }

                }
            }
            return message;
        }
    }
}
