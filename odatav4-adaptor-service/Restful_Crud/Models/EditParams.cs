using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restful_Crud.Models
{
    public class EditParams
    {
        public string key { get; set; }
        public string action { get; set; }
        public List<EventData> added { get; set; }
        public List<EventData> changed { get; set; }
        public List<EventData> deleted { get; set; }
        public EventData value { get; set; }
    }
}