using System;

namespace Adesso.Rideshare.Models.Objects
{
    public class JourneyPlan
    {
        public int Id { get; set; }

        public int DepartureCityId { get; set; }

        public int DestinationCityId { get; set; }

        public DateTime Date { get; set; }

        public int SeatCount { get; set; }

        public bool Status { get; set; }

    }
}
