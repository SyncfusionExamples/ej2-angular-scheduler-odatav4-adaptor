using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using Restful_Crud.Models;

namespace Restful_Crud.Controllers
{
    public class EventDatasController : ODataController
    {
        private ScheduleDataEntities1 db = new ScheduleDataEntities1();

        // GET: odata/EventDatas
        [EnableQuery]
        [AcceptVerbs("GET")]
        public IQueryable<EventData> GetEventDatas()
        {
            return db.EventDatas;
        }

        // GET: odata/EventDatas(5)
        [EnableQuery]
        [AcceptVerbs("GET")]
        public IQueryable<EventData> GetEventDatas(string StartDate, string EndDate)
        {
            DateTime start = DateTime.Parse(StartDate);
            DateTime end = DateTime.Parse(EndDate);
            return db.EventDatas.Where(evt => evt.StartTime >= start && evt.EndTime <= end);
        }

        // POST: odata/EventDatas
        [AcceptVerbs("POST", "OPTIONS")]
        public void Post([FromBody]CrudData eventData)
        {
            EventData insertData = new EventData();
            insertData.Id = (db.EventDatas.ToList().Count > 0 ? db.EventDatas.ToList().Max(p => p.Id) : 1) + 1;
            insertData.StartTime = Convert.ToDateTime(eventData.StartTime).ToLocalTime();
            insertData.EndTime = Convert.ToDateTime(eventData.EndTime).ToLocalTime();
            insertData.Subject = eventData.Subject;
            insertData.IsAllDay = eventData.IsAllDay;
            insertData.Location = eventData.Location;
            insertData.Description = eventData.Description;
            insertData.RecurrenceRule = eventData.RecurrenceRule;
            insertData.RecurrenceID = eventData.RecurrenceID;
            insertData.RecurrenceException = eventData.RecurrenceException;
            insertData.StartTimezone = eventData.StartTimezone;
            insertData.EndTimezone = eventData.EndTimezone;

            db.EventDatas.Add(insertData);
            db.SaveChanges();
        }

        // PATCH: odata/EventDatas(5)
        [AcceptVerbs("PATCH", "MERGE", "OPTIONS")]
        public void Patch([FromBody]CrudData eventData)
        {
            EventData updateData = db.EventDatas.Find(Convert.ToInt32(eventData.Id));
            if (updateData != null)
            {
                updateData.StartTime = Convert.ToDateTime(eventData.StartTime).ToLocalTime();
                updateData.EndTime = Convert.ToDateTime(eventData.EndTime).ToLocalTime();
                updateData.Subject = eventData.Subject;
                updateData.IsAllDay = eventData.IsAllDay;
                updateData.Location = eventData.Location;
                updateData.Description = eventData.Description;
                updateData.RecurrenceRule = eventData.RecurrenceRule;
                updateData.RecurrenceID = eventData.RecurrenceID;
                updateData.RecurrenceException = eventData.RecurrenceException;
                updateData.StartTimezone = eventData.StartTimezone;
                updateData.EndTimezone = eventData.EndTimezone;

                db.SaveChanges();
            }
        }

        // DELETE: odata/EventDatas(5)
        [AcceptVerbs("DELETE", "OPTIONS")]
        public void Delete([FromODataUri]int key)
        {
            EventData removeData = db.EventDatas.Find(key);
            if (removeData != null)
            {
                db.EventDatas.Remove(removeData);
                db.SaveChanges();
            }
        }
    }
}
