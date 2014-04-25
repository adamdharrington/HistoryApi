using HistoryApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace HistoryApp.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EventsController : ApiController
    {
        private DbGeography formatLoc(double lat, double lon) 
        { 
            return DbGeography.FromText("POINT(" + lon.ToString().Replace(",", ".") + " " + lat.ToString().Replace(",", ".") + ")", 4326);
        }

        private WebApiContext db = new WebApiContext();

        

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
