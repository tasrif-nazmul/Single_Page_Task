using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Single_Page_Task.Models
{
    public class MeetingMinutesDetail
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("MeetingMinutesMaster")]
        public int MeetingMinutesMaster_Id { get; set; }
        public string InterestProduct { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }

        public virtual MeetingMinutesMaster MeetingMinutesMaster { get; set; }
    }
}