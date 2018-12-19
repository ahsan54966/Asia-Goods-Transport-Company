using Fyp_First_Increment.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Fyp_First_Increment.ViewModel.Admin.Vehicles
{
    public class VehicleCRUD
    {


       
        public IEnumerable<Veh> VehicleList()
        {
            List<Veh> vehiclelist = new List<Veh>();
            string connection = ConfigurationManager.ConnectionStrings["temp_transport"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("select VehicleNumber from tbl_Veh", con);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    Veh vehicle = new Veh();
                    vehicle.VehicleNumber = sdr["VehicleNumber"].ToString();
                    vehiclelist.Add(vehicle);
                }
            }
            con.Close();
            return vehiclelist.AsEnumerable();
        }

        public Veh GetVehicleInformation(string VehicleNumber)
        {
            var VehicleData = new Veh();
            string connection = ConfigurationManager.ConnectionStrings["temp_transport"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from tbl_Veh where VehicleNumber='"+VehicleNumber+"'", con);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                if (sdr.Read())
                {
                    VehicleData.VehicleNumber = sdr["VehicleNumber"].ToString();
                    VehicleData.DriverName = sdr["DriverName"].ToString();
                    VehicleData.PhoneNumber = sdr["DriverPhoneNumber"].ToString();
                    VehicleData.VehicleSize = sdr["VehicleSize"].ToString();
                }
            }
            con.Close();
            return VehicleData;
        }
    }
}