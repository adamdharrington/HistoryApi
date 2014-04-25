using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Spatial;

namespace HistoryApp.Models
{
    public class APIEvent
    {
        public DbGeography formatLoc(double lat, double lon)
        {
            return DbGeography.FromText("POINT(" + lon.ToString().Replace(",", ".") + " " + lat.ToString().Replace(",", ".") + ")", 4326);
        }
        public void AddGeolocation() {
            Geolocation = formatLoc(Latitude, Longitude);
        }

        public int Id { get; set; }
        public String Name { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime EndDate { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime StartDate { get; set; }
        public String Category { get; set; }
        public Double Latitude { get; set; }
        public Double Longitude { get; set; }
        public String ImageName { get; set; }
        public String ImageUrl { get; set; }
        public String Excerpt { get; set; }
        public String Description { get; set; }
        public String SourceUrl { get; set; }
        public DbGeography Geolocation { get; private set; }
        /*{
            get
            {
                return formatLoc(Latitude, Longitude);
            }
            set
            {
                AddGeolocation();
            }
        }*/
    }
    public class WebApiContext : DbContext
    {
        public DbSet<APIEvent> Events { get; set; }
    }
}