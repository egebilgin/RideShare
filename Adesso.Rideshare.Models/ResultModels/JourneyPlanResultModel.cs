using System;

namespace Adesso.Rideshare.Models.ResultModels
{
    public class JourneyPlanResultModel
    {
        public int Id { get; set; }

        public int DepartureCityId { get; set; }

        public int DestinationCityId { get; set; }

        public DateTime Date { get; set; }

        public int SeatCount { get; set; }
    }
}
