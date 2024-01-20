using AutoMapper;
using Single_Page_Task.DTOs;
using Single_Page_Task.Models;
using Single_Page_Task.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Single_Page_Task.Controllers
{
    public class MeetingController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var db = new SPTContext();
            var customerNames = db.Customers.Select(c => c.CustomerName).ToList();
            var productNames = db.ProductsServices.Select(p => p.Name).ToList();

            ViewBag.CustomerNames = new SelectList(customerNames);
            ViewBag.ProductNames = new SelectList(productNames);

            return View();
        }


        [HttpPost]
        public ActionResult Index(MeetingProductDTO obj, string customerName)
        {

            var db = new SPTContext();

            var customerNames = db.Customers.Select(c => c.CustomerName).ToList();
            var productNames = db.ProductsServices.Select(p => p.Name).ToList();

            ViewBag.CustomerNames = new SelectList(customerNames);
            ViewBag.ProductNames = new SelectList(productNames);

            

            var MeetingDetails = new MeetingMinutesMaster
            {
                CustomerId = db.Customers
                    .Where(c => c.CustomerName == customerName)
                    .Select(c => c.Id)
                    .FirstOrDefault(),

                Date = obj.Date,
                Time = obj.Time,
                MeetingPlace = obj.MeetingPlace,
                AttendsFromClientSide = obj.AttendsFromClientSide,
                AttendsFromHostSide = obj.AttendsFromHostSide,
                MeetingAgenda = obj.MeetingAgenda,
                MeetingDecision = obj.MeetingDecision,
                MeetingDiscussion = obj.MeetingDiscussion
            };

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<MeetingProductDTO, MeetingMinutesMaster>();
            });

            var mapper = new Mapper(config);
            var data =  mapper.Map<MeetingMinutesMaster>(MeetingDetails);

            db.MeetingMinutesMasters.Add(data);


            
            var sessionData = Session["SelectedData"] as List<MeetingProductDTO> ?? new List<MeetingProductDTO>();

            foreach (var sessionEntry in sessionData)
            {
                var productDetail = new MeetingMinutesDetail
                {
                    MeetingMinutesMaster_Id = 2,
                    InterestProduct = sessionEntry.ProductNames,
                    Quantity = sessionEntry.ProductQuantity,
                    Unit = sessionEntry.ProductUnit
                };

                var config2 = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<MeetingProductDTO, MeetingMinutesDetail>();
                });

                var mapper2 = new Mapper(config2);
                var data2 = mapper.Map<MeetingMinutesDetail>(productDetail);
                db.MeetingMinutesDetails.Add(data2);
            }

            db.SaveChanges();



            return RedirectToAction("Index");
        }

        public JsonResult GetCustomerNames(string customerType)
        {
            var db = new SPTContext();
            List<string> customerNames;

            if (customerType == "Individual")
            {
                customerNames = db.Customers
                    .Where(c => c.Type == "Individual")
                    .Select(c => c.CustomerName)
                    .ToList();
            }
            else if (customerType == "Corporate")
            {
                customerNames = db.Customers
                    .Where(c => c.Type == "Corporate")
                    .Select(c => c.CustomerName)
                    .ToList();
            }
            else
            {
                customerNames = new List<string>();
            }

            return Json(customerNames, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult LoadProductDetails(string productName)
        {
            var db = new SPTContext();
            var unitName = db.ProductsServices
                .Where(p => p.Name == productName)
                .Select(p => p.Unit)
                .FirstOrDefault();

            return Json(new { Unit= unitName }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddToSession(MeetingProductDTO obj)
        {
            var sessionData = Session["SelectedData"] as List<MeetingProductDTO> ?? new List<MeetingProductDTO>();

            sessionData.Add(new MeetingProductDTO
            {
                ProductNames = obj.ProductNames,
                ProductQuantity = obj.ProductQuantity,
                ProductUnit = obj.ProductUnit
            });

            Session["SelectedData"] = sessionData;

            return Json(new { success = true });
        }


        [HttpGet]
        public ActionResult GetSessionData()
        {
            var sessionData = Session["SelectedData"] as List<MeetingProductDTO> ?? new List<MeetingProductDTO>();
            return Json(sessionData, JsonRequestBehavior.AllowGet);
        }
    }
}
