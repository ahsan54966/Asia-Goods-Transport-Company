using Fyp_First_Increment.Models;
using Fyp_First_Increment.ViewModel.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Fyp_First_Increment.Controllers;
using Fyp_First_Increment.ViewModel.Admin.Reports;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Data;
using Fyp_First_Increment.ViewModel.Home;
using Fyp_First_Increment.App_Start;
using Fyp_First_Increment.ViewModel.Admin.builty;
using Fyp_First_Increment.ViewModel.Admin.Vehicles;
namespace Fyp_First_Increment.Models
{ 
    [UserAuthentication]
    [Fyp_First_Increment.MvcApplication.NoDirectAccess]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index(string vehicleno = "")
        {
            //if (Session["Userdata"] == null)
            //{
            //    RedirectToAction("Login", "Registration", new { id = 1 });
            //}
            return View();

         
        }

      /*  
        public ActionResult AdminTruckProfitReports(int livecompanyid = 0)
        {
            
            ReportsCRUDViewModel Report = new ReportsCRUDViewModel();
            VehiclesCrudViewModel TruckList = new VehiclesCrudViewModel();
            // get This list from VehicleCrudViewModel
            var vehicles = TruckList.TruckList(livecompanyid);
            var reportviewmodel = new ReportsViewModel()
            {
                VehicleList = vehicles
            };

            return View(reportviewmodel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdminTruckProfitReports(Report report)
        {
            ModelState["DriverCat"].Errors.Clear();
            ModelState["ReportProfit"].Errors.Clear();
            ModelState["VehicleManufacture"].Errors.Clear();
            ModelState["VehicleType"].Errors.Clear();
                var ProfitReport = new ReportsCRUDViewModel();
                if(ModelState.IsValid)
                {
                    var ReportData = ProfitReport.VehicleProfitReportGenerate(report);
                    if (ReportData.Tables[0].Rows.Count != 0)
                    {
                        TempData["ReportData"] = ReportData;
                        TempData.Keep();
                        return RedirectToAction("GenerateTruckProfit", "Admin");
                    }
                    else
                    {
                        TempData["Message"] = "Data Not Exist";
                    }
                }
                VehiclesCrudViewModel TruckList = new VehiclesCrudViewModel();
                // get This list from VehicleCrudViewModel
                var vehicles = TruckList.TruckList(report.CompanyId);
                var reportviewmodel = new ReportsViewModel()
                {
                    VehicleList = vehicles
                };

                return View(reportviewmodel);
                
        }
        public void GenerateTruckProfit(Report report)
        {
                    var ReportData = (DataSet)TempData["ReportData"];
                    ReportDocument rd = new ReportDocument();
                    rd.Load(Path.Combine(Server.MapPath("~/Reports/RideProfitReport/CrystalReportTruckRideProfit.rpt")));
                    rd.SetDataSource(ReportData);
                    Response.Clear();
                    string filepath = Server.MapPath("~/" + "demo.pdf");
                    rd.ExportToDisk(ExportFormatType.PortableDocFormat, filepath);
                    FileInfo fileinfo = new FileInfo(filepath);
                    Response.AddHeader("Content-Disposition", "inline;filenam=demo.pdf");
                    Response.ContentType = "application/pdf";
                    Response.WriteFile(fileinfo.FullName);          
        }
        public ActionResult AdminTruckDriverReport(int livecompanyid = 0)
        {
            var Driver = new ReportsCRUDViewModel();
            var DriverCat = Driver.DriverCatagoryList();
            var viewmodel = new ReportsViewModel()
            {
                DriverCatagory = DriverCat
            };
            return View(viewmodel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdminTruckDriverReport(Report driver_type)
        {
            ModelState["ReportProfit"].Errors.Clear();
            ModelState["VehicleManufacture"].Errors.Clear();
            ModelState["VehicleType"].Errors.Clear();
            ModelState["ReportDateFrom"].Errors.Clear();
            ModelState["ReportDateTo"].Errors.Clear();
            ModelState["ReportVehicleNumber"].Errors.Clear();
            if (ModelState.IsValid)
            {
                try
                {

                    var reportdriver = new ReportsCRUDViewModel();
                    //Get Data Set here
                    var ReportData = reportdriver.ReportDrivers(driver_type);
                    if (ReportData.Tables[0].Rows.Count != 0)
                    {
                        //TempData["message"] = "Dont Match Record";
                        TempData["ReportData"] = ReportData;
                        TempData.Keep();
                        return RedirectToAction("GenerateTruckDriver", "Admin");
                    }
                    else
                    {
                        TempData["Message"] = "Data Not Exist";
                    }
                }
                catch (Exception e)
                {
                    ViewBag.Message = e.Message.ToString();
                }
            }
            var Driver = new ReportsCRUDViewModel();
            var DriverCat = Driver.DriverCatagoryList();
            var viewmodel = new ReportsViewModel()
            {
                DriverCatagory = DriverCat
            };
            return View(viewmodel);
        }
        // truck Driver Generation of Report Externel Method
        public void GenerateTruckDriver()
        {
            var ReportData = (DataSet)TempData["ReportData"];
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reports/Driver/CrystalReportBusDriver.rpt")));
            rd.SetDataSource(ReportData);
            Response.Clear();
            string filepath = Server.MapPath("~/" + "CrystalReportBusDriver.pdf");
            rd.ExportToDisk(ExportFormatType.PortableDocFormat, filepath);
            FileInfo fileinfo = new FileInfo(filepath);
            Response.AddHeader("Content-Disposition", "inline;filenam=CrystalReportBusDriver.pdf");
            Response.ContentType = "application/pdf";
            Response.WriteFile(fileinfo.FullName);
        }
        public ActionResult AdminTruckVehicleReport(int livecompanyid = 0)
        {
            var reportmethod = new ReportsCRUDViewModel();
            var VehicleManufacturer = reportmethod.VehicleCatagoryList();
            var viewmodel = new ReportsViewModel()
            {
                VehicleManuFacturerList = VehicleManufacturer
            };
            return View(viewmodel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdminTruckVehicleReport(Report report)
        {
            ModelState["DriverCat"].Errors.Clear();
            ModelState["ReportProfit"].Errors.Clear();
            ModelState["ReportVehicleNumber"].Errors.Clear();
            ModelState["AreaType"].Errors.Clear();
            ModelState["ReportDateFrom"].Errors.Clear();
            ModelState["ReportDateTo"].Errors.Clear();
            var reportmethod = new ReportsCRUDViewModel();
            if (ModelState.IsValid)
            {
                var ReportData = reportmethod.VehicleTruckCompanyList(report);
                if(ReportData.Tables[0].Rows.Count!=0)
                {
                    TempData["ReportData"] = ReportData;
                    TempData.Keep();
                    return RedirectToAction("TruckVehicleReport", "Admin");
                }
                else
                {
                    TempData["Message"] = "Data Not Exist";
                }
            }
            var VehicleManufacturer = reportmethod.VehicleCatagoryList();
            var viewmodel = new ReportsViewModel()
            {
                VehicleManuFacturerList = VehicleManufacturer
            };
            return View(viewmodel);
        }
        public void TruckVehicleReport(Report report)
        {
            
                var ReportData = (DataSet)TempData["ReportData"];
                ReportDocument rd = new ReportDocument();
                rd.Load(Path.Combine(Server.MapPath("~/Reports/Vehicle/Truck/CrystalReportTrucks.rpt")));
                rd.SetDataSource(ReportData);
                Response.Clear();
                string filepath = Server.MapPath("~/" + "TruckReport.pdf");
                rd.ExportToDisk(ExportFormatType.PortableDocFormat, filepath);
                FileInfo fileinfo = new FileInfo(filepath);
                Response.AddHeader("Content-Disposition", "inline;filenam=TruckReport.pdf");
                Response.ContentType = "application/pdf";
                Response.WriteFile(fileinfo.FullName);
            
        }
        //Truck Route Report
        public ActionResult AdminTruckRouteReport()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdminTruckRouteReport(Report report)
        {

            if (ModelState.IsValidField("ReportDateFrom") && ModelState.IsValidField("ReportDateTo"))
            {
                var ProfitReport = new ReportsCRUDViewModel();
                var ReportData = new DataSet();
                try
                {
                    ReportData = ProfitReport.VehicleComparativeReport(report);
                }
                catch (Exception e)
                {
                    TempData["error"] = e.Message;
                }
                if (ReportData.Tables[0].Rows.Count != 0)
                {
                    //TempData["message"] = "Dont Match Record";
                    //TempData.Keep();
                    TempData["ReportData"] = ReportData;
                    TempData.Keep();
                    return RedirectToAction("GenerateTruckComparativeReport", "Admin");
                }
                else
                {
                    TempData["Message"] = "Data Not Exist";
                }


            }
            return View(report);

        }
        public void GenerateTruckComparativeReport()
        {
            var ReportData = (DataSet)TempData["ReportData"];
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reports/ComparativeRoute/CrystalReportComparativeProfit.rpt")));
            rd.SetDataSource(ReportData);
            Response.Clear();
            string filepath = Server.MapPath("~/" + "ComparativeTruckReport.pdf");
            rd.ExportToDisk(ExportFormatType.PortableDocFormat, filepath);
            FileInfo fileinfo = new FileInfo(filepath);
            Response.AddHeader("Content-Disposition", "inline;filenam=ComparativeTruckReport.pdf");
            Response.ContentType = "application/pdf";
            Response.WriteFile(fileinfo.FullName);
        }
        */
        public ActionResult AdminTrackingArea()
        {
            return View();
        }
        public ActionResult AdminProfileSetting(int id=0)
        {
            //int user_id=int.Parse(Session["user_Id"].ToString());
            var method = new CustomerRegister();
            Users edituser = method.EditUser(id);
            return View(edituser);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdminProfileSetting(Users user)
        {
            ModelState["VehicleNumber"].Errors.Clear();
            ModelState["user_comp_type"].Errors.Clear();
            ModelState["user_comp"].Errors.Clear();
            ModelState["user_City"].Errors.Clear();
            ModelState["UserCnic"].Errors.Clear();
            ModelState["UserEmail"].Errors.Clear();
            ModelState["User_PhoneNumber"].Errors.Clear();
            ModelState["CompanyPhoneNumber"].Errors.Clear();
            ModelState["PinCode"].Errors.Clear();
             
                
            var method = new CustomerRegister();

            string message = "";
            var SavePath = "";
            if (ModelState.IsValid)
            {
                    if (user.image_file != null)
                    {
                        var FileLength = user.image_file.ContentLength;
                        var FileContentType = user.image_file.ContentType;
                        var extension = Path.GetExtension(user.image_file.FileName).ToLower();
                        var FileName = Path.GetFileNameWithoutExtension(user.image_file.FileName);
                        FileName = FileName + DateTime.Now.ToString("yymmssfff") + extension;
                        var FolderName = Server.MapPath("~/Pictures/Registeration/");
                        SavePath = Path.Combine(FolderName, FileName);
                        user.Image = SavePath.ToString();
                    }
                    try
                    {
                        message = method.UpdateUser(user);
                    

                    if (message == "1")
                    {
                        if (user.image_file != null)
                        {
                            user.image_file.SaveAs(SavePath);
                        }
                        message = "Admin Updated Successfully";
                        TempData["message"] = message;
                    }
                    else if (message == "0")
                    {
                        message = "Not Updated";
                        TempData["message"] = message;
                    }
                    }
                    catch (Exception e)
                    {
                        TempData["message"] = e.Message;
                    }
                }
            
            return View(user);
        }
        //Afzal Work from Here
        // Ride phase
        //For Bus
       
        //For Truck

        /*
         *         public ActionResult AdminTruckride(int livecompanyid= 0)
        {
            RideCRUDViewModel ridelist = new RideCRUDViewModel();
            var rides = ridelist.GetAllRide(livecompanyid);
            if(rides.Count()==0)
            {
                TempData["message"] = "No Ride Available";
            }
            return View(rides);
        }

        public ActionResult AdminTruckAddRide(int id = 0, int companyid = 0)
        {
            Ride editride = new Ride();
            RideCRUDViewModel TruckRide = new RideCRUDViewModel();
            VehiclesCrudViewModel TruckList = new VehiclesCrudViewModel();
            var cities = TruckRide.CityList();
            var drivers = TruckRide.DriverList(companyid);
            //Callthis Method from VehicleCRudView
            var vehicles = TruckList.TruckList(companyid);
            var viewmodel=new RideViewModel();
            if(id==0)
            {
                viewmodel = new RideViewModel(new Ride())
                {
                    Vehicles = vehicles,
                    Drivers = drivers,
                    Cities = cities
                };
            }
            else
            {
              
                    editride = TruckRide.editride(id,companyid);
                    viewmodel = new RideViewModel(new Ride())
                    {
                        Vehicles = vehicles,
                        Drivers = drivers,
                        Cities = cities,
                        RideId = editride.RideId,
                        RideSource = editride.RideSource,
                        RideDestination = editride.RideDestination,
                        RideDieselExpense = editride.RideDieselExpense,
                        RideMaintainanceExpense = editride.RideMaintainanceExpense,
                        RideFoodExpense = editride.RideFoodExpense,
                        RideMobileExpense = editride.RideMobileExpense,
                        RideTaxExpense = editride.RideTaxExpense,
                        RideDriverCharge = editride.RideDriverCharge,
                        RideCommisionCharge = editride.RideCommisionCharge,
                        RideDieselQuantity = editride.RideDieselQuantity,
                        RideDriverId = editride.RideDriverId,
                        RideVehicleNumber = editride.RideVehicleNumber,
                        RideProdit = editride.RideProdit,
                        RideSeller = editride.RideSeller,
                        RideBuyer = editride.RideBuyer,
                        RideFare = editride.RideFare,
                        RideDetail = editride.RideDetail,
                        RideDate = editride.RideDate,
                    };
                
            }
            
            return View(viewmodel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AdminTruckAddRide(Ride ride)
        {


            ModelState["RideConductorName"].Errors.Clear();
            ModelState["RidePassengerFare"].Errors.Clear();
            ModelState["RidePassengers"].Errors.Clear();
            //ModelState["RideDetail"].Errors.Clear();
            string message = "";
            RideCRUDViewModel CreateRide=new RideCRUDViewModel();
            var viewmodel = new RideViewModel();
            if(ModelState.IsValid)
            {
                if (ride.RideId == 0)
                {
                   
                    message = CreateRide.CreateRide(ride);
                    if (message != "")
                    {

                        var cities = CreateRide.CityList();
                        var drivers = CreateRide.DriverList(ride.CompanyId);
                        var vehicles = CreateRide.TruckList();
                        viewmodel = new RideViewModel(new Ride())
                        {
                            Vehicles = vehicles,
                            Drivers = drivers,
                            Cities = cities,
                        };
                        TempData["message"] = message;
                        return RedirectToAction("AdminTruckride", new { livecompanyid = Session["user_Id"] });

                    }
                    else
                    {
                        TempData["message"] = "Problem During Adding Ride";
                        return RedirectToAction("AdminTruckAddRide", new { livecompanyid = Session["user_Id"]});
                    }
                }
                else
                {
                    RideCRUDViewModel UpdateRide = new RideCRUDViewModel();
                    message = UpdateRide.RideUpdate(ride);
                    if (message != "")
                    {
                        TempData["message"] = message;
                        TempData.Keep();
                        return RedirectToAction("AdminTruckride", new { livecompanyid = Session["user_Id"] });
                    }
                    else
                    {
                        TempData["message"] = "Problem During Update Ride";
                        return RedirectToAction("AdminTruckAddRide", new { livecompanyid = Session["user_Id"] });
                    }
                }

            }
            else
            {
                var cities = CreateRide.CityList();
                var drivers = CreateRide.DriverList(ride.CompanyId);
                var vehicles = CreateRide.TruckList();
                viewmodel = new RideViewModel(new Ride())
                {
                    Vehicles = vehicles,
                    Drivers = drivers,
                    Cities = cities,
                };
            }


            return View(viewmodel);
        }
        public ActionResult AdmintruckrideDetail(int id=0,int companyid=0 )
        {
            
            RideCRUDViewModel TruckRide = new RideCRUDViewModel();
            //Return Detail of the truck Ride
            Ride busdetail = TruckRide.editride(id, companyid);
   
            return View(busdetail);
        }
        public ActionResult AdminTruckDeleteRide(int Id=0)
        {
            RideCRUDViewModel deleteride=new RideCRUDViewModel();
            string message=deleteride.RideDelete(Id);
            if (message != "")
                {
                    TempData["message"] = message;
                    TempData.Keep();
                    return RedirectToAction("AdminTruckride", new { livecompanyid = Session["user_Id"] });
                }
                else
                {
                    TempData["message"] = "Problem During Delete Ride";
                    TempData.Keep();
                    return RedirectToAction("AdminTruckride", new { livecompanyid = Session["user_Id"] });
                }
        }
         * 
         * 
         * 
         * 
         * */



        ////Builty Module start here

        public JsonResult VehicleNumber(string Prefix)
        {
            var VehCRUD = new VehicleCRUD();
            var ObjList = VehCRUD.VehicleList();
            //Searching records from list using LINQ query  
            var VehicleData = (from N in ObjList
                            where N.VehicleNumber.StartsWith(Prefix)
                            select new { N.VehicleNumber });
            
            return Json(VehicleData, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetVehicleInformation(string VehicleNumber)
        {
            var VehCRUD = new VehicleCRUD();
            var VehicleInformation = VehCRUD.GetVehicleInformation(VehicleNumber);
            return Json(VehicleInformation,JsonRequestBehavior.AllowGet);
        }
        public ActionResult BuiltyHome(int livecompanyid = 0)
        {
            BuiltyCRuDViewModel AllBuilty = new BuiltyCRuDViewModel();
            var builty = AllBuilty.GetAllBuilty(livecompanyid);
            if (builty.Count() == 0)
            {
                TempData["BuiltyHomeMessage"]+= "NO Record Found!";
            }
            return View(builty);
        }

        public ActionResult BuiltyDetail(int id = 0, int companyid = 0)
        {

            BuiltyCRuDViewModel BuiltyDetail = new BuiltyCRuDViewModel();

            Builty builtydetail = BuiltyDetail.editbuilty(id, companyid);
            return View(builtydetail);


        }


        
        public ActionResult NewBuilty(int id = 0, int companyid = 0)
        {
            Builty editBuilty = new Builty();

            BuiltyCRuDViewModel EditBuilty = new BuiltyCRuDViewModel();

            //Callthis Method from VehicleCRudView
            var viewmodel = new BuiltyViewModel();
            if (id != 0)
            {
                editBuilty = EditBuilty.editbuilty(id, companyid);

             /*   viewmodel = new BuiltyViewModel()
                {
                    Vehicles = vehicles,
                    Drivers = drivers,
                    builty=editBuilty
                    
                };*/

            }
            var GoodsDetailList = EditBuilty.GoodsDetailList();
            editBuilty.BuiltyDetailList = GoodsDetailList;

            return View(editBuilty);

        }
        [HttpPost]
        public ActionResult NewBuilty(Builty builty)
        {
            var ReportData = new DataSet();
            string message = "";
            BuiltyCRuDViewModel builtycrud = new BuiltyCRuDViewModel();
            var viewmodel = new BuiltyViewModel();
            ModelState["BuiltyDetail"].Errors.Clear();
            if(ModelState.IsValid)
            {
                if (builty.BuiltyId == 0)
                {
                    try
                    {
                        ReportData = builtycrud.Builty(builty);
                        if (ReportData.Tables[0].Rows.Count != 0)
                        {
                            TempData["ReportData"] = ReportData;
                            TempData.Keep();
                            return RedirectToAction("GenerateBuilty", "Admin");
                        }
                    }
                    catch(Exception e)
                    {
                        message = e.Message;
                    }

//                    return RedirectToAction("builtyhome", "Admin", new { livecompanyid = Session["user_Id"] });

                }
                else
                {
                    try
                    {
                        ReportData = builtycrud.BuiltyUpdate(builty);

                        if (ReportData.Tables[0].Rows.Count != 0)
                        {
                            TempData["ReportData"] = ReportData;
                            TempData.Keep();
                            return RedirectToAction("GenerateBuilty", "Admin");
                        }

                    }
                    catch (Exception e)
                    {
                        message = e.Message;
                    }

                    /*    if (message != "")
                        {
                            TempData["message"] = "Builty update sucessfully";
                            TempData.Keep();
                            return RedirectToAction("builtyhome", "Admin", new { livecompanyid = Session["user_Id"] });
                        }
                        else
                        {*/

            //        return RedirectToAction("builtyhome", "Admin", new { livecompanyid = Session["user_Id"] });

                }

            }
            TempData["GenerateBuiltyMessage"] = message;
  /*          viewmodel = new BuiltyViewModel()
            {
                builty = builty
            };
   */
            var GoodsDetailList = builtycrud.GoodsDetailList();
            builty.BuiltyDetailList = GoodsDetailList;
            return View(builty);
        }

        public ActionResult BuiltyDelete(string id, int companyid = 0)
        {
            string message = "";
            if (id == "")
            {
                TempData["message"] = "Id Missing";

            }
            else
            {

                BuiltyCRuDViewModel builtydlete = new BuiltyCRuDViewModel();
                try
                {
                    string result = builtydlete.BuiltyDelete(id, companyid);
                    if (result == "1")
                    {
                        message = "Builty Deleted Successfully";
                        TempData["BuiltyHomeMessage"] = message;
                    }
                    else if (result == "0")
                    {
                        message = "Problem During Delete";
                        TempData["BuiltyHomeMessage"] = message;
                    }
                }
                catch (Exception e)
                {
                    TempData["BuiltyHomeMessage"] = e.Message.ToString();
                }

            }

            return RedirectToAction("builtyhome", "Admin", new { livecompanyid = Session["user_id"] });
        }

        /// Print Builty
        /// 

        public void GenerateBuilty()
        {
            var ReportData = (DataSet)TempData["ReportData"];
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reports/Builty/CrystalReportFinalBuilty.rpt")));
            rd.SetDataSource(ReportData);
            Response.Clear();
            string filepath = Server.MapPath("~/" + "CrystalReportFinalBuilty.pdf");
            rd.ExportToDisk(ExportFormatType.PortableDocFormat, filepath);
            FileInfo fileinfo = new FileInfo(filepath);
            Response.AddHeader("Content-Disposition", "inline;filenam=CrystalReportFinalBuilty.pdf");
            Response.ContentType = "application/pdf";
            Response.WriteFile(fileinfo.FullName);
        }





    }



}