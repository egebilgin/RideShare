using Adesso.Rideshare.Models.Objects;
using Adesso.Rideshare.Models.ResultModels;
using Adesso.RideShare.Common.Responses;
using Adesso.RideShare.DataTransferObjects;
using Adesso.RideShare.Service.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Adesso.RideShare.Controllers
{
    [RoutePrefix("journeyplan")]
    public class JourneyPlanController : ApiController
    {

        private readonly IRideShareService rideShareService;

        public JourneyPlanController(IRideShareService rideShareService)
        {
            this.rideShareService = rideShareService;
        }

        [Route("create"), HttpPost]
        [ResponseType(typeof(RideShareServiceResponse<JourneyPlanDTO>))]
        public IHttpActionResult CreateJourneyPlan([FromBody] JourneyPlanDTO journeyPlan)
        {
            rideShareService.CreateJourneyPlan(new JourneyPlanResultModel
            {
                Date = journeyPlan.Date,
                DepartureCityId = journeyPlan.DepartureCityId,
                DestinationCityId = journeyPlan.DestinationCityId,
                SeatCount = journeyPlan.SeatCount
            });
            var dataList = new List<JourneyPlan>();
            dataList.Add(new JourneyPlan
            {
                Date = journeyPlan.Date,
                DepartureCityId = journeyPlan.DepartureCityId,
                DestinationCityId = journeyPlan.DestinationCityId,
                SeatCount = journeyPlan.SeatCount
            });
            var response = new RideShareServiceResponse<JourneyPlan>()
            {
                Result = dataList,
                SuccessText = "Successfully added!"
            };
            return base.Ok(response);
        }

        [Route("updatestatus"), HttpPost]
        public IHttpActionResult UpdateJourneyPlanStatus([FromBody] JourneyPlanDTO journeyPlan)
        {
            rideShareService.UpdateJourneyPlanStatus(new JourneyPlanStatusUpdateResultModel
            {
                Id = journeyPlan.Id,
                Status = journeyPlan.Status
            });
            var dataList = new List<JourneyPlanUpdate>();
            dataList.Add(new JourneyPlanUpdate
            {
                Id = journeyPlan.Id,
                Status = journeyPlan.Status
            });
            var response = new RideShareServiceResponse<JourneyPlanUpdate>()
            {
                Result = dataList,
                SuccessText = "Successfully updated!"
            };
            return base.Ok(response);
        }

        [Route("search"), HttpPost]
        public IHttpActionResult SearchJourneyPlan([FromBody] JourneyPlanSearchResultModel journeyPlan)
        {

            var result = rideShareService.SearchJourneyPlan(new JourneyPlanSearchResultModel
            {
                StartDate = journeyPlan.StartDate,
                EndDate = journeyPlan.EndDate
            });
            result.SuccessText = "Successfully listed!";
            return base.Ok(result);

        }

        [Route("book"), HttpPost]
        public IHttpActionResult BookJourneyPlan([FromBody] JourneyPlanDTO journeyPlan)
        {
            var response = rideShareService.BookJourneyPlan(new JourneyPlanBookResultModel
            {
                Id = journeyPlan.Id
            });
            return base.Ok(response);
        }
    }
}
