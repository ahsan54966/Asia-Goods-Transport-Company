using Fyp_First_Increment.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
namespace Fyp_First_Increment.ViewModel.Admin
{
    public class RideCRUDViewModel
    {

        /// <summary>
        /// Truck Section Start From Here
        /// </summary>
        /// <returns></returns>

        public IEnumerable<Users> DriverList(int companyid=0)
        {
            List<Users> driverlist = new List<Users>();
            string connection = ConfigurationManager.ConnectionStrings["temp_transport"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_User_Truckdrivers", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CompanyId", companyid);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    Users driver = new Users();
                    driver.UserFirstName = sdr["User_FirstName"].ToString();
                    driver.UserId = int.Parse(sdr["UserId"].ToString());
                    driverlist.Add(driver);
                }
            }
            con.Close();
            return driverlist.AsEnumerable();
        }

        //Create
        public string CreateRide(Ride ride)
        {
            ride.RideType = "Truck";
            string message="";
            string connection = ConfigurationManager.ConnectionStrings["temp_transport"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            int RideExpenses= int.Parse(ride.RideCommisionCharge.ToString())
                + int.Parse(ride.RideDieselExpense.ToString()) + int.Parse(ride.RideDriverCharge.ToString())
                + int.Parse(ride.RideFoodExpense.ToString()) + int.Parse(ride.RideMaintainanceExpense.ToString()) +
                int.Parse(ride.RideMobileExpense.ToString()) + int.Parse(ride.RideTaxExpense.ToString());
            int RideFare = int.Parse(ride.RideFare.ToString());
            int RideProfit = RideFare-RideExpenses;
            SqlCommand cmd = new SqlCommand("sp_Ride_create", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Ride_Source", ride.RideSource.ToString());
            cmd.Parameters.AddWithValue("@Ride_Destination", ride.RideDestination.ToString());
            cmd.Parameters.AddWithValue("@Ride_DieselExpenses", int.Parse(ride.RideDieselExpense.ToString()));
            cmd.Parameters.AddWithValue("@Ride_MaintainanceExpenses", int.Parse(ride.RideMaintainanceExpense.ToString()));
            cmd.Parameters.AddWithValue("@Ride_FoodExpenses", int.Parse(ride.RideFoodExpense.ToString()));
            cmd.Parameters.AddWithValue("@Ride_MobileExpenses", int.Parse(ride.RideMobileExpense.ToString()));
            cmd.Parameters.AddWithValue("@Ride_TaxExpenses", int.Parse(ride.RideTaxExpense.ToString()));
            cmd.Parameters.AddWithValue("@Ride_DriverCharges", int.Parse(ride.RideDriverCharge.ToString()));
            cmd.Parameters.AddWithValue("@Ride_CommisionCharges", int.Parse(ride.RideCommisionCharge.ToString()));
            cmd.Parameters.AddWithValue("@Ride_DieselQuantity", ride.RideDieselQuantity.ToString());
            cmd.Parameters.AddWithValue("@Ride_DriverId", int.Parse(ride.RideDriverId.ToString()));
            cmd.Parameters.AddWithValue("@Ride_VehicleNumber", ride.RideVehicleNumber.ToString());
            cmd.Parameters.AddWithValue("@Ride_ProfitLoss", RideProfit);
            cmd.Parameters.AddWithValue("@RideSeller", ride.RideSeller.ToString());
            cmd.Parameters.AddWithValue("@RideBuyer", ride.RideBuyer);
            cmd.Parameters.AddWithValue("@RideFare", RideFare);
            cmd.Parameters.AddWithValue("@RideDate",ride.RideDate.Date);
            cmd.Parameters.AddWithValue("@RideDetail",ride.RideDetail.ToString());
            cmd.Parameters.AddWithValue("@RideType", ride.RideType.ToString());
            cmd.Parameters.AddWithValue("@companyId", ride.CompanyId);
            int result=cmd.ExecuteNonQuery();
            if(result>0)
            {
                message = "Ride Added Successfully";
                ride = new Ride();
            }
            con.Close();
            return message;
        }
        public IEnumerable<Ride> GetAllRide(int id=0)
        {
            List<Ride> ridelist = new List<Ride>();
            string connection = ConfigurationManager.ConnectionStrings["temp_transport"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_Ride_GetAllTruckRides", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CompanyId", id);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    Ride ride = new Ride();

                    ride.RideId = int.Parse(sdr["Ride_Id"].ToString());
                    ride.RideSource = sdr["Ride_Source"].ToString();
                    ride.RideDestination = sdr["Ride_Destination"].ToString();
                    ride.RideDieselExpense = int.Parse(sdr["Ride_DieselExpenses"].ToString());
                    ride.RideMaintainanceExpense = int.Parse(sdr["Ride_MaintainanceExpenses"].ToString());
                    ride.RideFoodExpense = int.Parse(sdr["Ride_FoodExpenses"].ToString());
                    ride.RideMobileExpense = int.Parse(sdr["Ride_MobileExpenses"].ToString());
                    ride.RideTaxExpense = int.Parse(sdr["Ride_TaxExpenses"].ToString());
                    ride.RideDriverCharge = int.Parse(sdr["Ride_DriverCharges"].ToString());
                    ride.RideCommisionCharge = int.Parse(sdr["Ride_CommisionCharges"].ToString());
                    ride.RideDieselQuantity = sdr["Ride_DieselQuantity"].ToString();
                    ride.RideDriverId = int.Parse(sdr["Ride_DriverId"].ToString());
                    ride.RideVehicleNumber = sdr["Ride_VehicleNumber"].ToString();
                    ride.RideProdit = int.Parse(sdr["Ride_ProfitLoss"].ToString());
                    ride.RideSeller = sdr["RideSeller"].ToString();
                    ride.RideBuyer = sdr["RideBuyer"].ToString();
                    ride.RideFare = int.Parse(sdr["RideFare"].ToString());
                    ride.RideDate = DateTime.Parse(sdr["RideDate"].ToString()).Date;
                    ride.RideDetail = sdr["RideDetail"].ToString();
                    ridelist.Add(ride);
                }
            }
            con.Close();
            return ridelist.AsEnumerable();
        }
        public Ride editride(int id=0,int comid=0)
        {
            Ride ride=new Ride();
            string connection = ConfigurationManager.ConnectionStrings["temp_transport"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_Ride_select", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@RideId", id);
            cmd.Parameters.AddWithValue("@CompanyId", comid);

            SqlDataReader sdr = cmd.ExecuteReader();
            if(sdr.HasRows)
            {
                while(sdr.Read())
                {
                    ride.RideId = int.Parse(sdr["Ride_Id"].ToString());
                    ride.RideSource = sdr["Ride_Source"].ToString();
                    ride.RideDestination = sdr["Ride_Destination"].ToString();
                    ride.RideDieselExpense = int.Parse(sdr["Ride_DieselExpenses"].ToString());
                    ride.RideMaintainanceExpense = int.Parse(sdr["Ride_MaintainanceExpenses"].ToString());
                    ride.RideFoodExpense = int.Parse(sdr["Ride_FoodExpenses"].ToString());
                    ride.RideMobileExpense = int.Parse(sdr["Ride_MobileExpenses"].ToString());
                    ride.RideTaxExpense = int.Parse(sdr["Ride_TaxExpenses"].ToString());
                    ride.RideDriverCharge = int.Parse(sdr["Ride_DriverCharges"].ToString());
                    ride.RideCommisionCharge = int.Parse(sdr["Ride_CommisionCharges"].ToString());
                    ride.RideDieselQuantity = sdr["Ride_DieselQuantity"].ToString();
                    ride.RideDriverId = int.Parse(sdr["Ride_DriverId"].ToString());
                    ride.RideVehicleNumber = sdr["Ride_VehicleNumber"].ToString();
                    ride.RideProdit = int.Parse(sdr["Ride_ProfitLoss"].ToString());
                    ride.RideSeller = sdr["RideSeller"].ToString();
                    ride.RideBuyer = sdr["RideBuyer"].ToString();
                    ride.RideFare = int.Parse(sdr["RideFare"].ToString());
                    ride.RideDate = DateTime.Parse(sdr["RideDate"].ToString());
                    ride.RideDetail = sdr["RideDetail"].ToString();
                    ride.CompanyId = int.Parse(sdr["RideCompanyId"].ToString());
                }
            }
            con.Close();
            return ride;
        }
        public string RideUpdate(Ride ride)
        {
            string message = "";
            string connection = ConfigurationManager.ConnectionStrings["temp_transport"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            int RideExpenses = int.Parse(ride.RideCommisionCharge.ToString())
                + int.Parse(ride.RideDieselExpense.ToString()) + int.Parse(ride.RideDriverCharge.ToString())
                + int.Parse(ride.RideFoodExpense.ToString()) + int.Parse(ride.RideMaintainanceExpense.ToString()) +
                int.Parse(ride.RideMobileExpense.ToString()) + int.Parse(ride.RideTaxExpense.ToString());
            int RideFare = int.Parse(ride.RideFare.ToString());
            int RideProfit = RideFare - RideExpenses;
            SqlCommand cmd = new SqlCommand("sp_Ride_update", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("RideId", int.Parse(ride.RideId.ToString()));
            cmd.Parameters.AddWithValue("@Ride_Source", ride.RideSource.ToString());
            cmd.Parameters.AddWithValue("@Ride_Destination", ride.RideDestination.ToString());
            cmd.Parameters.AddWithValue("@Ride_DieselExpenses", int.Parse(ride.RideDieselExpense.ToString()));
            cmd.Parameters.AddWithValue("@Ride_MaintainanceExpenses", int.Parse(ride.RideMaintainanceExpense.ToString()));
            cmd.Parameters.AddWithValue("@Ride_FoodExpenses", int.Parse(ride.RideFoodExpense.ToString()));
            cmd.Parameters.AddWithValue("@Ride_MobileExpenses", int.Parse(ride.RideMobileExpense.ToString()));
            cmd.Parameters.AddWithValue("@Ride_TaxExpenses", int.Parse(ride.RideTaxExpense.ToString()));
            cmd.Parameters.AddWithValue("@Ride_DriverCharges", int.Parse(ride.RideDriverCharge.ToString()));
            cmd.Parameters.AddWithValue("@Ride_CommisionCharges", int.Parse(ride.RideCommisionCharge.ToString()));
            cmd.Parameters.AddWithValue("@Ride_DieselQuantity", ride.RideDieselQuantity.ToString());
            cmd.Parameters.AddWithValue("@Ride_DriverId", int.Parse(ride.RideDriverId.ToString()));
            cmd.Parameters.AddWithValue("@Ride_VehicleNumber", ride.RideVehicleNumber.ToString());
            cmd.Parameters.AddWithValue("@Ride_ProfitLoss", RideProfit);
            cmd.Parameters.AddWithValue("@RideSeller", ride.RideSeller.ToString());
            cmd.Parameters.AddWithValue("@RideBuyer", ride.RideBuyer);
            cmd.Parameters.AddWithValue("@RideFare", RideFare);
            cmd.Parameters.AddWithValue("@RideDate", ride.RideDate.ToString());
            cmd.Parameters.AddWithValue("@RideDetail", ride.RideDetail.ToString());
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                message = "Ride Updated Successfully";
                ride = new Ride();
            }
            con.Close();
            return message;
        }
        public string RideDelete(int id=0)
        {
            string message = "";
            Ride ride = new Ride();
            string connection = ConfigurationManager.ConnectionStrings["temp_transport"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_Ride_delete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@RideId", id);
            int mes= cmd.ExecuteNonQuery();
            if(mes>0)
            {
                message = "Ride Successfully Deleted";
            }
            else
            {
                message = "Problem During deleting Ride";
            }
            con.Close();
            return message;
        }




    }
}