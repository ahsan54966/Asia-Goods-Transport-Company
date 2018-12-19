using Fyp_First_Increment.Models;
using Fyp_First_Increment.Reports.Builty;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Fyp_First_Increment.Controllers
{
    class BuiltyCRuDViewModel
    {
        public DataSet Builty(Builty builty)
        {
            int BuiltyId = 0;
            DataSet ds = new FinalBuiltyDataSet();
            string connection = ConfigurationManager.ConnectionStrings["temp_transport"].ConnectionString;

            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cmd0 = new SqlCommand("sp_Vehicle_VehicleExist", con);
            cmd0.CommandType = CommandType.StoredProcedure;
            cmd0.Parameters.AddWithValue("@VehicleNumber", builty.BuiltyVehicleNumber);
            SqlDataReader sdr = cmd0.ExecuteReader();
            if (sdr.HasRows)
            {

                if(sdr.Read())
                {
                    if (sdr["DriverName"] != builty.DriverName || sdr["DriverPhoneNumber"] != builty.DriverPhoneNumber || sdr["VehicleSize"] != builty.VehicleSize)
                    {
                        SqlCommand cmd1 = new SqlCommand("sp_Vehicle_VehicleUpdate", con);
                        cmd1.CommandType = CommandType.StoredProcedure;
                        cmd1.Parameters.AddWithValue("@VehicleNumber", builty.BuiltyVehicleNumber);
                        cmd1.Parameters.AddWithValue("@DriverName", builty.DriverName);
                        cmd1.Parameters.AddWithValue("@DriverPhoneNumber", builty.DriverPhoneNumber);
                        cmd1.Parameters.AddWithValue("@VehicleSize", builty.VehicleSize);
                        cmd1.ExecuteNonQuery();
                    }
                }

            }
            else
            {
                SqlCommand cmd1 = new SqlCommand("sp_Vehicle_VehicleAdd", con);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@VehicleNumber", builty.BuiltyVehicleNumber);
                cmd1.Parameters.AddWithValue("@DriverName", builty.DriverName);
                cmd1.Parameters.AddWithValue("@DriverPhoneNumber", builty.DriverPhoneNumber);
                cmd1.Parameters.AddWithValue("@VehicleSize", builty.VehicleSize);
                cmd1.ExecuteNonQuery();
            }

            SqlCommand cmd = new SqlCommand("sp_NewBuilty", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BuiltyVehicleNumber", builty.BuiltyVehicleNumber.ToString());
            cmd.Parameters.AddWithValue("@BuiltySellerName", builty.BuiltySeller.ToString());
            cmd.Parameters.AddWithValue("@BuiltyBuyerName", builty.BuiltyBuyer.ToString());
            cmd.Parameters.AddWithValue("@BuiltySource", builty.BuiltySource.ToString());
            cmd.Parameters.AddWithValue("@BuiltyDestination", builty.BuiltyDestination.ToString());

            cmd.Parameters.AddWithValue("@BuiltyDate", builty.BuiltyDate.ToString());
            cmd.Parameters.AddWithValue("@DriverNumber", builty.DriverPhoneNumber.ToString());
            cmd.Parameters.AddWithValue("@BuiltyDriverName", builty.DriverName.ToString());
            cmd.Parameters.AddWithValue("@BuiltyVehicleSize", builty.VehicleSize.ToString());
            cmd.Parameters.AddWithValue("@Quantity", builty.BuiltyGoodsQuantaty.ToString());
            cmd.Parameters.AddWithValue("@BuiltyDetail", builty.BuiltyDetail.ToString());
         
            cmd.Parameters.AddWithValue("@BuiltyWeight", builty.BuiltyWeight.ToString());
            
            SqlDataAdapter SDA = new SqlDataAdapter(cmd);
            DataTable DT = new DataTable();
            SDA.Fill(DT);
            if (DT.Rows.Count > 0)
            { 
                foreach(DataRow Row in DT.Rows)
                {
                    BuiltyId = int.Parse(Row["BuiltyId"].ToString());
                }
            }

           
                con.Close();
               cmd.Dispose();
                using (SqlCommand cm = new SqlCommand("sp_Builty_Report", con))
                {
                    cm.CommandType = System.Data.CommandType.StoredProcedure;


                    
                    cm.Parameters.AddWithValue("@BuiltyId",BuiltyId);

                    SqlDataAdapter sda = new SqlDataAdapter(cm);
                    

                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow r in dt.Rows)
                        {

                            string firstname = r["BuiltySource"].ToString();
                            string lastname = r["DriverName"].ToString();
                           

                        
                        }
                    }


                   sda.Fill(ds, "tbl_Builty");

                    }
              

            

            return ds;
        }

        public IEnumerable<Builty> GetAllBuilty(int livecompanyid)
        {
            List<Builty> ridelist = new List<Builty>();
            string connection = ConfigurationManager.ConnectionStrings["temp_transport"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_Builty_GetAllBuilty", con);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@CompanyId", livecompanyid);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    Builty builty = new Builty();

                    builty.BuiltyId = int.Parse(sdr["BuiltyId"].ToString());
                    builty.BuiltySource = sdr["BuiltySource"].ToString();
                    builty.BuiltyDestination = sdr["BuiltyDestination"].ToString();

                    
                    builty.BuiltyVehicleNumber = sdr["BuiltyVehicleNumber"].ToString();

                    builty.BuiltySeller = sdr["BuiltySellerName"].ToString();
                    builty.BuiltyBuyer = sdr["BuiltyBuyerName"].ToString();
                   
                    builty.BuiltyDate = DateTime.Parse(sdr["BuiltyDate"].ToString()).Date;
                    builty.BuiltyDetail = sdr["BuiltyDetail"].ToString();
                   
              
                    ridelist.Add(builty);
                }
            }
            con.Close();
            return ridelist.AsEnumerable();
        }

        public Builty editbuilty(int id, int companyid)
        {

            Builty builty = new Builty();
            string connection = ConfigurationManager.ConnectionStrings["temp_transport"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_Builty_Select", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BuiltyId ", id);
          

            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    builty.BuiltyId = int.Parse(sdr["BuiltyId"].ToString());
                    builty.BuiltySource = sdr["BuiltySource"].ToString();
                    builty.BuiltyDestination = sdr["BuiltyDestination"].ToString();
                    builty.DriverName = sdr["DriverName"].ToString();
                    builty.VehicleSize = sdr["VehicleSize"].ToString();
                    builty.BuiltyGoodsQuantaty = sdr["quantity"].ToString();
                    builty.BuiltyVehicleNumber = sdr["BuiltyVehicleNumber"].ToString();

                    builty.BuiltySeller = sdr["BuiltySellerName"].ToString();
                    builty.BuiltyBuyer = sdr["BuiltyBuyerName"].ToString();
                    builty.DriverPhoneNumber = sdr["DriverNumber"].ToString();
                    builty.BuiltyDate = DateTime.Parse(sdr["BuiltyDate"].ToString());
                    builty.BuiltyDetail = sdr["BuiltyDetail"].ToString();          
                    builty.BuiltyWeight = sdr["BuiltyWeight"].ToString();
                 
                    
                }
            }
            con.Close();
            return builty;
       
        }

        public DataSet BuiltyUpdate(Builty builty)
        {
        

            string connection = ConfigurationManager.ConnectionStrings["temp_transport"].ConnectionString;

            SqlConnection con = new SqlConnection(connection);
            DataSet ds = new BuiltyDataSet();
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_Builty_Update", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@BuiltyId", builty.BuiltyId.ToString());
            cmd.Parameters.AddWithValue("@BuiltyVehicleNumber", builty.BuiltyVehicleNumber.ToString());
            cmd.Parameters.AddWithValue("@BuiltySellerName", builty.BuiltySeller.ToString());
            cmd.Parameters.AddWithValue("@BuiltyBuyerName", builty.BuiltyBuyer.ToString());
            cmd.Parameters.AddWithValue("@BuiltySource", builty.BuiltySource.ToString());
            cmd.Parameters.AddWithValue("@BuiltyDestination", builty.BuiltyDestination.ToString());

            cmd.Parameters.AddWithValue("@BuiltyDate", builty.BuiltyDate.ToString());
            cmd.Parameters.AddWithValue("@DriverNumber", builty.DriverPhoneNumber.ToString());
            cmd.Parameters.AddWithValue("@BuiltyDriverName", builty.DriverName.ToString());
            cmd.Parameters.AddWithValue("@BuiltyVehicleSize", builty.VehicleSize.ToString());
            cmd.Parameters.AddWithValue("@Quantity", builty.BuiltyGoodsQuantaty.ToString());
            cmd.Parameters.AddWithValue("@BuiltyDetail", builty.BuiltyDetail.ToString());

            cmd.Parameters.AddWithValue("@BuiltyWeight", builty.BuiltyWeight.ToString());
       
            string message = "";
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                message = "Ride Added Successfully";

            }
            con.Close();
            using (SqlCommand cm = new SqlCommand("sp_Builty_Report", con))
            {
                cm.CommandType = System.Data.CommandType.StoredProcedure;



                cm.Parameters.AddWithValue("@BuiltyId",builty.BuiltyId);

                SqlDataAdapter sda = new SqlDataAdapter(cm);


                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow r in dt.Rows)
                    {

                        string firstname = r["DriverNumber"].ToString();
                 



                    }
                }


                sda.Fill(ds, "tbl_Builty");

            }
           



            return ds;
            
        }

        public String BuiltyDelete(string id, int companyid)
        {
        
            string message = "";
            string connection = ConfigurationManager.ConnectionStrings["temp_transport"].ConnectionString;
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_Delete_Builty", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BuiltyId", id);
              
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    message = "1";
                }
                else if (cmd.ExecuteNonQuery() == 0)
                {
                    message = "0";
                }
                else
                {
                    throw new Exception("Problem During Delete");
                }

                con.Close();
            return message;

        }
        public List<string> GoodsDetailList()
        {
            List<string> GoodsList = new List<string>();
            GoodsList.Add("FH Reel");
            GoodsList.Add("FH Packet");
            GoodsList.Add("FH Pailot");
            GoodsList.Add("CD Gata Open Nishan");
            GoodsList.Add("CD Gata Mod");
            return GoodsList;
        }
        /* 
         public List<Builty> GoodsDetailList()
        {
            var GoodsDetailList = new List<Builty>(){
                new Builty{BuiltyDetail="FH Reel"},
                new Builty{BuiltyDetail="FH Packet"},
                new Builty{BuiltyDetail="FH Pailot"},
                new Builty{BuiltyDetail="CD Gata Open Nishan"},
                new Builty{BuiltyDetail="CD Gata Mod"}
            };              
            return GoodsDetailList;
        }
         */
        ////List for Goods Detail
        
    }
}
