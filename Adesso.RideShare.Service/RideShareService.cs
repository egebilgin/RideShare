using Adesso.Rideshare.Models.Objects;
using Adesso.Rideshare.Models.ResultModels;
using Adesso.RideShare.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;

namespace Adesso.RideShare.Service
{
    public class RideShareService : ServiceBase, IRideShareService
    {
        public Common.Models.Responses.RideShareServiceResponse<List<JourneyPlan>> CreateJourneyPlan(JourneyPlanResultModel model)
        {
            var r = new Common.Models.Responses.RideShareServiceResponse<List<JourneyPlan>>();
           
            var journeyPlan = new JourneyPlan()
            {
                Date = model.Date,
                DepartureCityId = model.DepartureCityId,
                DestinationCityId = model.DestinationCityId,
                SeatCount = model.SeatCount
            };

            // DB Insert

            return r;
        }

        public Common.Models.Responses.RideShareServiceResponse<List<JourneyPlan>> UpdateJourneyPlanStatus(JourneyPlanStatusUpdateResultModel model)
        {
            var r = new Common.Models.Responses.RideShareServiceResponse<List<JourneyPlan>>();

            // DB Update

            return r;
        }

        public Common.Models.Responses.RideShareServiceResponse<List<JourneyPlan>> SearchJourneyPlan(JourneyPlanSearchResultModel model)
        {
            // DB Select

            var items = new List<JourneyPlan>();
            items.Add(new JourneyPlan
            {
                Date = new DateTime(2015, 12, 31),
                DepartureCityId = 34,
                DestinationCityId = 35,
                Id = 1,
                SeatCount = 3,
                Status = true
            });
            items.Add(new JourneyPlan
            {
                Date = new DateTime(2019, 10, 3),
                DepartureCityId = 06,
                DestinationCityId = 34,
                Id = 2,
                SeatCount = 1,
                Status = false
            });
            var r = new Common.Models.Responses.RideShareServiceResponse<List<JourneyPlan>>
            {
                Result = items
            };
            return r;
        }

        public Common.Models.Responses.RideShareServiceResponse<List<JourneyPlan>> BookJourneyPlan(JourneyPlanBookResultModel model)
        {
            // DB Select

            var items = new List<JourneyPlan>();
            items.Add(new JourneyPlan
            {
                Date = new DateTime(2015, 12, 31),
                DepartureCityId = 34,
                DestinationCityId = 35,
                Id = 1,
                SeatCount = 0,
                Status = true
            });
            items.Add(new JourneyPlan
            {
                Date = new DateTime(2019, 10, 3),
                DepartureCityId = 06,
                DestinationCityId = 34,
                Id = 2,
                SeatCount = 0,
                Status = false
            });
            items = items.Where(x => x.SeatCount > 1 && x.Id == model.Id).ToList();
            if (!items.Any())
            {
                var r = new Common.Models.Responses.RideShareServiceResponse<List<JourneyPlan>>
                {
                    ErrorText = "Insufficient seats!"
                };
                return r;
            }
            return new Common.Models.Responses.RideShareServiceResponse<List<JourneyPlan>>
            {
                SuccessText = "Success!"
            };
        }
    }
}
