using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Single_Page_Task.DTOs
{
    public class MeetingProductDTO
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public string MeetingPlace { get; set; }
        public string AttendsFromClientSide { get; set; }
        public string AttendsFromHostSide { get; set; }
        public string MeetingAgenda { get; set; }
        public string MeetingDiscussion { get; set; }
        public string MeetingDecision { get; set; }
        public string ProductNames { get; set; }
        //public MeetingProductDTO()
        //{
        //    // Assuming you have access to the controller's ViewBag in the constructor
        //    // Replace ViewBag.ProductNames with your actual data source
        //    ProductNames = new SelectList(ViewBag.ProductNames as List<string> ?? new List<string>());
        //}
        public int ProductQuantity { get; set; }
        public string ProductUnit { get; set; }
    }
}