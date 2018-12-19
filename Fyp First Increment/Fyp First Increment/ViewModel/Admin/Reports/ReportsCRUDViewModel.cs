using Fyp_First_Increment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using Fyp_First_Increment.Reports.Driver;
using Fyp_First_Increment.Reports.Vehicle.Bus;
using Fyp_First_Increment.Reports.RideProfitReport;
using Fyp_First_Increment.Reports.Vehicle.Truck;
using System.Configuration;
using Fyp_First_Increment.Reports.ComparativeRoute;

namespace Fyp_First_Increment.ViewModel.Admin.Reports
{
    //Buses Portion Start From Here
    public class ReportsCRUDViewModel
    {
        //public IEnumerable<Vehicle> TruckList()
        //{
        //    List<Vehicle> vehiclelist = new List<Vehicle>();
        //    SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9AHLO7G\SQLEXPRESS;Database=temp_transport;Integrated Security=True");
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand("select Vehicle_Number from tbl_Vehicle where Vehicle_Catagory='Truck'", con);
        //    SqlDataReader sdr = cmd.ExecuteReader();
        //    if (sdr.HasRows)
        //    {
        //        while (sdr.Read())
        //        {
        //            Vehicle veh = new Vehicle();
        //            veh.VehicleNumber = sdr["Vehicle_Number"].ToString();
        //            vehiclelist.Add(veh);
        //        }
        //    }
        //    return vehiclelist.AsEnumerable();
        //}
        //public IEnumerable<Users> DriverList()
        //{
        //    List<Users> driverlist = new List<Users>();
        //    SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9AHLO7G\SQLEXPRESS;Database=temp_transport;Integrated Security=True");
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand("sp_User_Truckdrivers", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    SqlDataReader sdr = cmd.ExecuteReader();
        //    if (sdr.HasRows)
        //    {
        //        while (sdr.Read())
        //        {
        //            Users driver = new Users();
        //            driver.UserFirstName = sdr["User_FirstName"].ToString();
        //            driver.UserId = int.Parse(sdr["UserId"].ToString());
        //            driverlist.Add(driver);
        //        }
        //    }
        //    return driverlist.AsEnumerable();
        //}
        //public IEnumerable<Ride> GetAllRide()
        //{
        //    List<Ride> ridelist = new List<Ride>();
        //    SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9AHLO7G\SQLEXPRESS;Database=temp_transport;Integrated Security=True");
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand("select * from tbl_Ride where RideType='Truck'", con);
        //    SqlDataReader sdr = cmd.ExecuteReader();
        //    if (sdr.HasRows)
        //    {
        //        while (sdr.Read())
        //        {
        //            Ride ride = new Ride();

        //            ride.RideId = int.Parse(sdr["Ride_Id"].ToString());
        //            ride.RideSource = sdr["Ride_Source"].ToString();
        //            ride.RideDestination = sdr["Ride_Destination"].ToString();
        //            ride.RideDieselExpense = int.Parse(sdr["Ride_DieselExpenses"].ToString());
        //            ride.RideMaintainanceExpense = int.Parse(sdr["Ride_MaintainanceExpenses"].ToString());
        //            ride.RideFoodExpense = int.Parse(sdr["Ride_FoodExpenses"].ToString());
        //            ride.RideMobileExpense = int.Parse(sdr["Ride_MobileExpenses"].ToString());
        //            ride.RideTaxExpense = int.Parse(sdr["Ride_TaxExpenses"].ToString());
        //            ride.RideDriverCharge = int.Parse(sdr["Ride_DriverCharges"].ToString());
        //            ride.RideCommisionCharge = int.Parse(sdr["Ride_CommisionCharges"].ToString());
        //            ride.RideDieselQuantity = sdr["Ride_DieselQuantity"].ToString();
        //            ride.RideDriverId = int.Parse(sdr["Ride_DriverId"].ToString());
        //            ride.RideVehicleNumber = sdr["Ride_VehicleNumber"].ToString();
        //            ride.RideProdit = int.Parse(sdr["Ride_ProfitLoss"].ToString());
        //            ride.RideSeller = sdr["RideSeller"].ToString();
        //            ride.RideBuyer = sdr["RideBuyer"].ToString();
        //            ride.RideFare = int.Parse(sdr["RideFare"].ToString());
        //            ride.RideDate = DateTime.Parse(sdr["RideDate"].ToString());
        //            ride.RideDetail = sdr["RideDetail"].ToString();
        //            ridelist.Add(ride);
        //        }
        //    }
        //    return ridelist.AsEnumerable();
        //}
        //public IEnumerable<Vehicle> BusList()
        //{
        //    List<Vehicle> vehiclelist = new List<Vehicle>();
        //    SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9AHLO7G\SQLEXPRESS;Database=temp_transport;Integrated Security=True");
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand("select Vehicle_Number from tbl_Vehicle where Vehicle_Catagory='Bus'", con);
        //    SqlDataReader sdr = cmd.ExecuteReader();
        //    if (sdr.HasRows)
        //    {
        //        while (sdr.Read())
        //        {
        //            Vehicle veh = new Vehicle();
        //            veh.VehicleNumber = sdr["Vehicle_Number"].ToString();
        //            vehiclelist.Add(veh);
        //        }
        //    }
        //    return vehiclelist.AsEnumerable();
        //}
        //public IEnumerable<Ride> GetAllBusRide()
        //{
        //    List<Ride> ridelist = new List<Ride>();
        //    SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9AHLO7G\SQLEXPRESS;Database=temp_transport;Integrated Security=True");
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand("select * from tbl_Ride where RideType='Bus'", con);
        //    SqlDataReader sdr = cmd.ExecuteReader();
        //    if (sdr.HasRows)
        //    {
        //        while (sdr.Read())
        //        {
        //            Ride ride = new Ride();

        //            ride.RideId = int.Parse(sdr["Ride_Id"].ToString());
        //            ride.RideSource = sdr["Ride_Source"].ToString();
        //            ride.RideDestination = sdr["Ride_Destination"].ToString();
        //            ride.RideDieselExpense = int.Parse(sdr["Ride_DieselExpenses"].ToString());
        //            ride.RideMaintainanceExpense = int.Parse(sdr["Ride_MaintainanceExpenses"].ToString());
        //            ride.RideFoodExpense = int.Parse(sdr["Ride_FoodExpenses"].ToString());
        //            ride.RideMobileExpense = int.Parse(sdr["Ride_MobileExpenses"].ToString());
        //            ride.RideTaxExpense = int.Parse(sdr["Ride_TaxExpenses"].ToString());
        //            ride.RideDriverCharge = int.Parse(sdr["Ride_DriverCharges"].ToString());
        //            ride.RideCommisionCharge = int.Parse(sdr["Ride_CommisionCharges"].ToString());
        //            ride.RideDieselQuantity = sdr["Ride_DieselQuantity"].ToString();
        //            ride.RideDriverId = int.Parse(sdr["Ride_DriverId"].ToString());
        //            ride.RideVehicleNumber = sdr["Ride_VehicleNumber"].ToString();
        //            ride.RideProdit = int.Parse(sdr["Ride_ProfitLoss"].ToString());
        //            ride.RideSeller = sdr["RideSeller"].ToString();
        //            ride.RideBuyer = sdr["RideBuyer"].ToString();
        //            ride.RideFare = int.Parse(sdr["RideFare"].ToString());
        //            ride.RideDate = DateTime.Parse(sdr["RideDate"].ToString());
        //            ride.RideDetail = sdr["RideDetail"].ToString();
        //            ridelist.Add(ride);
        //        }
        //    }
        //    return ridelist.AsEnumerable();
        //}
        //Driver Reporting Start From Here
        /*
                  public List<Driver> DriverCatagoryList()
                {
                    var CatagoryList = new List<Driver>
                        {
                        new Driver { DriverPostion="First" },
                        new Driver { DriverPostion="Second" },
                        new Driver { DriverPostion="All" }
                        };
                   return CatagoryList;
                }
         */
        //Get All Drivers
        //public IEnumerable<Driver> ReportDrivers(Report driverreport)
        //{

        //    List<Driver> DriverList = new List<Driver>();
        //    SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9AHLO7G\SQLEXPRESS;Database=temp_transport;Integrated Security=True");
        //    con.Open();
        //    SqlCommand cmd=new SqlCommand();
        //    string drivercat = driverreport.DriverCat.ToString();
        //    if(driverreport.DriverType=="Bus")
        //    {
        //        if(drivercat=="First" || drivercat=="Second")
        //        {
        //            cmd = new SqlCommand("sp_User_ReportDrivers", con);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@DriverType", driverreport.DriverType.ToString());
        //            cmd.Parameters.AddWithValue("@DriverPosition", driverreport.DriverCat.ToString());
        //        }
        //        else if(drivercat=="All")
        //        {
        //            cmd = new SqlCommand("sp_User_ReportALLDrivers", con);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@DriverType", driverreport.DriverType.ToString());
        //        }
        //    }
        //    else if(driverreport.DriverType=="Truck")
        //    {
        //        if (drivercat == "First" || drivercat == "Second")
        //        {
        //            cmd = new SqlCommand("sp_User_ReportDrivers", con);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@DriverType", driverreport.DriverType.ToString());
        //            cmd.Parameters.AddWithValue("@DriverPosition", driverreport.DriverCat.ToString());
        //        }
        //        else if (drivercat == "All")
        //        {
        //            cmd = new SqlCommand("sp_User_ReportALLDrivers", con);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@DriverType", driverreport.DriverType.ToString());
        //        }
        //    }
        //    else
        //    {
        //        throw new Exception("Invalid Request");
        //    }
        //    SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //    DataSet ds = new DataSetBusDriver();
        //    sda.Fill(ds, "tbl_User");
        //    sda.Fill(ds, "tbl_Deiver");
        //    SqlDataReader sdr = cmd.ExecuteReader();
        //    if(sdr.HasRows)
        //    {
        //        while(sdr.Read())
        //        {
        //            Driver driver = new Driver();
        //            driver.UserId = int.Parse(sdr["UserId"].ToString());
        //            driver.UserFirstName = sdr["User_FirstName"].ToString();
        //            driver.UserLastName = sdr["User_LastName"].ToString();
        //            driver.User_PhoneNumber=sdr["User_PhoneNumber"].ToString();
        //            driver.UserAddress=sdr["User_Address"].ToString();
        //            driver.UserCnic=sdr["User_Cnic"].ToString();
        //            driver.UserEmail=sdr["User_Email"].ToString();
        //            driver.User_Password=sdr["User_Password"].ToString();
        //            driver.UserRoleId=int.Parse(sdr["User_Role_Id"].ToString());
        //            driver.Image = sdr["User_Image"].ToString();
        //            driver.DriverSalary=int.Parse(sdr["DriverSalary"].ToString());
        //            driver.DriverExperience=sdr["DriverExperience"].ToString();
        //            driver.DriverType=sdr["DriverType"].ToString();
        //            driver.DriverPostion=sdr["DriverPosition"].ToString();    
        //            driver.DriverRouteCharge=sdr["DriverRouteCharge"].ToString();
        //            driver.DriverUserId = int.Parse(sdr["DriverUserId"].ToString());
        //            DriverList.Add(driver);            
        //        }
        //    }
        //    //SqlCommand cmd = new SqlCommand("select * from tbl_Ride where RideType='Bus'", con);
        //    return DriverList;
        //}
        /// <summary>
        /// DataSet Report trial
        public DataSet ReportDrivers(Report driverreport)
        {
            string connection = ConfigurationManager.ConnectionStrings["temp_transport"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            string drivercat = driverreport.DriverCat.ToString();
            if (driverreport.AreaType == "Bus")
            {
                if (drivercat == "First" || drivercat == "Second")
                {
                    cmd = new SqlCommand("sp_User_ReportDrivers", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DriverType", driverreport.AreaType.ToString());
                    cmd.Parameters.AddWithValue("@DriverPosition", driverreport.DriverCat.ToString());
                    cmd.Parameters.AddWithValue("@CompanyId", driverreport.CompanyId);
                }
                else if (drivercat == "All")
                {
                    cmd = new SqlCommand("sp_User_ReportALLDrivers", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DriverType", driverreport.AreaType.ToString());
                    cmd.Parameters.AddWithValue("@CompanyId", driverreport.CompanyId);
                }
            }
            else if (driverreport.AreaType == "Truck")
            {
                if (drivercat == "First" || drivercat == "Second")
                {
                    cmd = new SqlCommand("sp_User_ReportDrivers", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DriverType", driverreport.AreaType.ToString());
                    cmd.Parameters.AddWithValue("@DriverPosition", driverreport.DriverCat.ToString());
                    cmd.Parameters.AddWithValue("@CompanyId", driverreport.CompanyId);
                }
                else if (drivercat == "All")
                {
                    cmd = new SqlCommand("sp_User_ReportALLDrivers", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DriverType", driverreport.AreaType.ToString());
                    cmd.Parameters.AddWithValue("@CompanyId", driverreport.CompanyId);
                }
            }
            else
            {
                throw new Exception("Invalid Request");
            }
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSetBusDriver();
            sda.Fill(ds, "tbl_User");
            sda.Fill(ds, "tbl_Deiver");
            return ds;
        }
        /// </summary>
        /// <returns></returns>
        /*
         public List<Vehicle> VehicleCatagoryList()
        {
            var CatagoryList = new List<Vehicle>
                {
                new Vehicle { VehicleManufacturer="Hino" },
                new Vehicle { VehicleManufacturer="Isuzu" },
                new Vehicle {VehicleManufacturer="Power"},
                new Vehicle {VehicleManufacturer="Nissan"},
                new Vehicle {VehicleManufacturer="Man"},
                new Vehicle {VehicleManufacturer="Mazda"}
                };
            return CatagoryList;
        } 
         */

        // Return vehicles according to company for vehcile reporting
        //public IEnumerable<Vehicle> VehicleCompanyList(Report report)
        //{
        //    List<Vehicle> VehicleList = new List<Vehicle>();
        //    SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9AHLO7G\SQLEXPRESS;Database=temp_transport;Integrated Security=True");
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand();
        //    string vehicletype = report.VehicleType.ToString();
        //    if(vehicletype=="Bus")
        //    {
        //       cmd=new SqlCommand("sp_User_ReportVehicles",con);
        //    }
        //    else if(vehicletype=="Truck")
        //    {
        //        cmd = new SqlCommand("sp_User_ReportTruckVehicles", con);
        //    }
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@VehicleType", report.VehicleManufacture.ToString());
        //    SqlDataReader sdr = cmd.ExecuteReader();
        //    if(sdr.HasRows)
        //    {
        //        while(sdr.Read())
        //        {
        //            if(vehicletype=="Bus")
        //            {
        //                Bus bus = new Bus();
        //                bus.VehicleNumber = sdr["Vehicle_Number"].ToString();
        //                bus.VehicleCatagory =sdr["Vehicle_Catagory"].ToString();
        //                bus.VehicleCapacity =sdr["Vehicle_Capacity"].ToString();
        //                bus.VehicleSize =sdr["Vehicle_Size"].ToString();
        //                bus.VehicleManufacturer =sdr["Vehicle_Manufacturer"].ToString();
        //                bus.VehicleRoute =sdr["Vehicle_Route"].ToString();
        //                bus.VehicleImageUrl =sdr["Vehicle_ImageUrl"].ToString();
        //                bus.BusCapacity =sdr["BusCapacity"].ToString();
        //                bus.BusRoute =sdr["BusRoute"].ToString();
        //                bus.BusModel =sdr["BusModel"].ToString();
        //                bus.BusId =sdr["BusId"].ToString();
        //                VehicleList.Add(bus);
        //            }
        //            else if(vehicletype=="Truck")
        //            {
        //                Truck truck = new Truck();
        //                truck.VehicleNumber = sdr["Vehicle_Number"].ToString();
        //                truck.VehicleCatagory = sdr["Vehicle_Catagory"].ToString();
        //                truck.VehicleCapacity = sdr["Vehicle_Capacity"].ToString();
        //                truck.VehicleSize = sdr["Vehicle_Size"].ToString();
        //                truck.VehicleManufacturer = sdr["Vehicle_Manufacturer"].ToString();
        //                truck.VehicleRoute = sdr["Vehicle_Route"].ToString();
        //                truck.VehicleImageUrl = sdr["Vehicle_ImageUrl"].ToString();
        //                truck.TruckCatagory = sdr["TruckCatagory"].ToString();
        //                truck.TruckCapacity = sdr["TruckCapacity"].ToString();
        //                truck.TruckSize = sdr["TruckSize"].ToString();
        //                truck.TruckRating = sdr["TruckRating"].ToString();
        //                truck.TruckType = sdr["TruckType"].ToString();
        //                truck.TruckId = sdr["TruckId"].ToString();
        //                VehicleList.Add(truck);
        //            }

        //        }
        //    }
        //    return VehicleList.AsEnumerable();
        //}

        //public IEnumerable<Bus> VehicleBusCompanyList(Report report)
        //{
        //    List<Bus> VehicleList = new List<Bus>();
        //    SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9AHLO7G\SQLEXPRESS;Database=temp_transport;Integrated Security=True");
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand();
        //    cmd = new SqlCommand("sp_User_ReportVehicles", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@VehicleType", report.VehicleManufacture.ToString());
        //    SqlDataReader sdr = cmd.ExecuteReader();
        //    if (sdr.HasRows)
        //    {
        //        while (sdr.Read())
        //        {
        //                Bus bus = new Bus();
        //                bus.VehicleNumber = sdr["Vehicle_Number"].ToString();
        //                bus.VehicleCatagory = sdr["Vehicle_Catagory"].ToString();
        //                bus.VehicleCapacity = sdr["Vehicle_Capacity"].ToString();
        //                bus.VehicleSize = sdr["Vehicle_Size"].ToString();
        //                bus.VehicleManufacturer = sdr["Vehicle_Manufacturer"].ToString();
        //                bus.VehicleRoute = sdr["Vehicle_Route"].ToString();
        //                bus.VehicleImageUrl = sdr["Vehicle_ImageUrl"].ToString();
        //                bus.BusCapacity = sdr["BusCapacity"].ToString();
        //                bus.BusRoute = sdr["BusRoute"].ToString();
        //                bus.BusModel = sdr["BusModel"].ToString();
        //                bus.BusId = sdr["BusId"].ToString();
        //                VehicleList.Add(bus);
        //        }
        //      }
            
        //    return VehicleList.AsEnumerable();
        //}
        //////////Data Set For Buses Here
        public DataSet VehicleBusCompanyList(Report report)
        {
            string connection = ConfigurationManager.ConnectionStrings["temp_transport"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand("sp_User_ReportVehicles", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@VehicleType", report.VehicleManufacture.ToString());
            cmd.Parameters.AddWithValue("@CompanyId", report.CompanyId);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSetBus();
            sda.Fill(ds, "tbl_Vehicle");
            sda.Fill(ds, "tbl_Bus");
            return ds;
        }
        // Return vehicles according to company for vehcile Truck reporting
        public DataSet VehicleTruckCompanyList(Report report)
        {
            string connection = ConfigurationManager.ConnectionStrings["temp_transport"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand("sp_User_ReportTruckVehicles", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@VehicleType", report.VehicleManufacture.ToString());
            cmd.Parameters.AddWithValue("@CompanyId", report.CompanyId);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSetTrucks();
            sda.Fill(ds, "tbl_Vehicle");
            sda.Fill(ds, "tbl_Truck");
            return ds;
        }
        //public IEnumerable<Truck> VehicleTruckCompanyList(Report report)
        //{
        //    List<Truck> VehicleList = new List<Truck>();
        //    SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-9AHLO7G\SQLEXPRESS;Database=temp_transport;Integrated Security=True");
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand();
        //    cmd = new SqlCommand("sp_User_ReportTruckVehicles", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@VehicleType", report.VehicleManufacture.ToString());
        //    SqlDataReader sdr = cmd.ExecuteReader();
        //    if (sdr.HasRows)
        //    {
        //        while (sdr.Read())
        //        {
        //                Truck truck = new Truck();
        //                truck.VehicleNumber = sdr["Vehicle_Number"].ToString();
        //                truck.VehicleCatagory = sdr["Vehicle_Catagory"].ToString();
        //                truck.VehicleCapacity = sdr["Vehicle_Capacity"].ToString();
        //                truck.VehicleSize = sdr["Vehicle_Size"].ToString();
        //                truck.VehicleManufacturer = sdr["Vehicle_Manufacturer"].ToString();
        //                truck.VehicleRoute = sdr["Vehicle_Route"].ToString();
        //                truck.VehicleImageUrl = sdr["Vehicle_ImageUrl"].ToString();
        //                truck.TruckCatagory = sdr["TruckCatagory"].ToString();
        //                truck.TruckCapacity = sdr["TruckCapacity"].ToString();
        //                truck.TruckSize = sdr["TruckSize"].ToString();
        //                truck.TruckRating = sdr["TruckRating"].ToString();
        //                truck.TruckType = sdr["TruckType"].ToString();
        //                truck.TruckId = sdr["TruckId"].ToString();
        //                VehicleList.Add(truck);
        //        }
        //    }
        //    return VehicleList.AsEnumerable();
        //}


        // Return DataSet to report Profit of Buses and Trucks
        public DataSet VehicleProfitReportGenerate(Report report)
        {

            string connection = ConfigurationManager.ConnectionStrings["temp_transport"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            //cmd = new SqlCommand("sp_Ride_RideReportProfit", con);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@AreaType", report.AreaType.ToString());
            //cmd.Parameters.AddWithValue("@VehicleNumber", report.ReportVehicleNumber.ToString());
            
            string ReportTime = report.ReportDurationType.ToString();
            int year = int.Parse(report.ReportDateTo.Year.ToString());
            int month = int.Parse(report.ReportDateTo.Month.ToString());
            switch (ReportTime)
            {
                case "custom":
                    {
                        cmd = new SqlCommand("sp_Ride_RideReportProfit", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@AreaType", report.AreaType.ToString());
                        cmd.Parameters.AddWithValue("@VehicleNumber", report.ReportVehicleNumber.ToString());
                        cmd.Parameters.AddWithValue("@DateFrom", report.ReportDateFrom.ToString());
                        cmd.Parameters.AddWithValue("@DateTo", report.ReportDateTo.ToString());
                        

                        break;
                    }
                case "yearly":
                    {
                        cmd = new SqlCommand("sp_Ride_RideReportProfitYear", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@AreaType", report.AreaType.ToString());
                        cmd.Parameters.AddWithValue("@VehicleNumber", report.ReportVehicleNumber.ToString());
                        cmd.Parameters.AddWithValue("@Year", year);
                        break;
                    }
                case "monthly":
                    {
                        cmd = new SqlCommand("sp_Ride_RideReportProfitYearandMonth", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@AreaType", report.AreaType.ToString());
                        cmd.Parameters.AddWithValue("@VehicleNumber", report.ReportVehicleNumber.ToString());
                        cmd.Parameters.AddWithValue("@Year", year);
                        cmd.Parameters.AddWithValue("@Month", month);
                        break;
                    }

                case "specific":
                    {
                        cmd = new SqlCommand("sp_Ride_RideReportProfitSpecificDate", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@AreaType", report.AreaType.ToString());
                        cmd.Parameters.AddWithValue("@VehicleNumber", report.ReportVehicleNumber.ToString());
                        cmd.Parameters.AddWithValue("@Date", report.ReportDateTo);
                        break;
                    }
                //case "LastFifteen":
                //    {
                //        cmd = new SqlCommand("sp_Ride_RideReportProfit", con);
                //        cmd.CommandType = CommandType.StoredProcedure;
                //        cmd.Parameters.AddWithValue("@AreaType", report.AreaType.ToString());
                //        cmd.Parameters.AddWithValue("@VehicleNumber", report.ReportVehicleNumber.ToString());
                //        cmd.Parameters.AddWithValue("@Date1", report.ReportDateFrom.ToString());
                //        cmd.Parameters.AddWithValue("@Date2", report.ReportDateTo.ToString());
                //        break;
                //    }
                default:
                    {
                        break;
                    }

            }
            cmd.Parameters.AddWithValue("@CompanyId", report.CompanyId);
            SqlDataAdapter sdr = new SqlDataAdapter(cmd);
            DataSet ds = new DataSetVehicleProfit();
            sdr.Fill(ds, "tbl_Ride");
            return ds;
        }

        public DataSet VehicleComparativeReport(Report report)
        {
            string connection = ConfigurationManager.ConnectionStrings["temp_transport"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand("sp_Ride_ComparativeReport", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DateFrom", report.ReportDateFrom);
            cmd.Parameters.AddWithValue("@DateTo", report.ReportDateTo);
            cmd.Parameters.AddWithValue("@AreaType", report.AreaType);
            cmd.Parameters.AddWithValue("@CompanyId", report.CompanyId);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSetComparativeRoute();
            sda.Fill(ds, "tbl_Ride");
            return ds;
        }
    }
}