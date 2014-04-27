using HistoryApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Script.Serialization;
using HistoryApp.Models.ViewModels;

namespace HistoryApp.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EventsController : ApiController
    {
        private WebApiContext db = new WebApiContext();


        private DbGeography formatLoc(double lat, double lon) 
        { 
            return DbGeography.FromText("POINT(" + lon.ToString().Replace(",", ".") + " " + lat.ToString().Replace(",", ".") + ")", 4326);
        }

        private IEnumerable<APIEvent> GetEventsByTime(DateTime StartTime, DateTime EndTime) 
        {

            var events = from e in db.Events
                         where e.EndDate < EndTime
                         where e.StartDate > StartTime
                         select e;                     
            return events;
        }

        private string formatJson(IEnumerable<APIEvent> results)
        {
            List<APIViewmodel> list = new List<APIViewmodel>();
            JavaScriptSerializer s = new JavaScriptSerializer();
            foreach ( var result in results)
            {
                var r = new APIViewmodel( result );
                list.Add(r);
            }
 
            return s.Serialize(list);
        }


        // ===================== Public Interface ========================

        // http://localhost:50931/4/5/6?startdate=01-01-1560&enddate=01-01-1950
        [Route("api/{zoom}/{lat}/{lon}")]
        [HttpGet]
        public IHttpActionResult GetClosest(int zoom, Double lat, Double lon, string startdate, string enddate)
        {
            // POINT(Long Lat)
            var s = DateTime.Parse(startdate);
            var e = DateTime.Parse(enddate);
            var results = formatJson(GetEventsByTime(s, e));

            return Json(results);

        }

        public IEnumerable<APIEvent> GetEventsByCategory(string category)
        {
            var events = from e in db.Events
                         select e;

            if (category != null)
            {
                
                var evs = events.Where((ep) => ep.Category.Contains(category));
                return evs;
            }

            return events;
        }

        public IEnumerable<APIEvent> GetEventsByName(string name)
        {
            var events = from e in db.Events
                         select e;

            if (name != null)
            {
                var evs = events.Where((ep) => ep.Name.Contains(name));
                return evs;
            }
            return events;
        }

        [Route("api/{zoom}/{lat}/{lon}")]
        [HttpGet]
        public IEnumerable<APIEvent> GetClosest(int zoom, Double lat, Double lon)
        {
            // POINT(Long Lat)

            var searchRef = formatLoc(lat, lon);

            var nearest = (from h in db.Events
                           let geo = searchRef
                           orderby geo.Distance(h.Geolocation)
                           select h).Take(2);
            return nearest;


        }

        [Route("api/events")]
        [HttpGet]
        public IEnumerable<APIEvent> GetAllEvents()
        {
            var events = (from e in db.Events
                         select e)
                         .Take(4); // How many to take from matched entries

            return events;
        }
    }

}
