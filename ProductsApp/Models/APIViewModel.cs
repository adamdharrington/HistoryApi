using System;

namespace HistoryApp.Models.ViewModels
{
    public class APIViewmodel
    {

        // properties


        public String name { get; set; }
        public String description { get; set; }
        public String excerpt { get; set; }
        public Object location { get; set; }
        public Object startDate { get; set; }
        public Object endDate { get; set; }
        public Object images { get; set; }

        // constructor

        public APIViewmodel(APIEvent realEvent) 
        {
            this.location = new
            {
                latitude = realEvent.Latitude,
                longitude = realEvent.Longitude
            };
            this.images = new
            {
                name = realEvent.ImageName,
                url = realEvent.ImageUrl
            };
            this.startDate = new
            {
                day = realEvent.StartDate.Day,
                month = realEvent.StartDate.Month,
                year = realEvent.StartDate.Year
            };
            this.endDate = new
            {
                day = realEvent.EndDate.Day,
                month = realEvent.EndDate.Month,
                year = realEvent.EndDate.Year
            };
            this.name = realEvent.Name;
            this.description = realEvent.Description;
            this.excerpt = realEvent.Excerpt;
        }


    }
}