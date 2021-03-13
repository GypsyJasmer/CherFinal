using CherFanPage.Models.DM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CherFanPage.Models
{
    public class TimelineModel
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Description { get; set; }


        public DateTime EventDate { get; set; }

        public List<TimelineEventAction> Actions { get; set; }



    }


}
