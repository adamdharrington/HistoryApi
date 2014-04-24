using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Spatial;

namespace HistoryApp.Models
{
    public class APIEvent
    {
        private DbGeography formatLoc(double lat, double lon)
        {
            return DbGeography.FromText("POINT(" + lon.ToString().Replace(",", ".") + " " + lat.ToString().Replace(",", ".") + ")", 4326);
        }

        public int Id { get; set; }
        public String Name { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime StartDate { get; set; }
        public String Category { get; set; }
        public Double Latitude { get; set; }
        public Double Longitude { get; set; }
        public String ImageName { get; set; }
        public String ImageUrl { get; set; }
        public String Excerpt { get; set; }
        public String Description { get; set; }
        public String SourceUrl { get; set; }
        public DbGeography Geolocation
        {
            get
            {
                return formatLoc(Latitude, Longitude);
            }
        }
    }
}