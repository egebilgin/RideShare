
using Adesso.Rideshare.Models.Objects;
using Adesso.Rideshare.Models.ResultModels;
using Adesso.RideShare.Common.Models.Responses;
using System.Collections.Generic;

namespace Adesso.RideShare.Service.Interfaces
{
    public interface IRideShareService
    {
        RideShareServiceResponse<List<JourneyPlan>> CreateJourneyPlan(JourneyPlanResultModel model);

        RideShareServiceResponse<List<JourneyPlan>> UpdateJourneyPlanStatus(JourneyPlanStatusUpdateResultModel model);

        RideShareServiceResponse<List<JourneyPlan>> SearchJourneyPlan(JourneyPlanSearchResultModel model);

        RideShareServiceResponse<List<JourneyPlan>> BookJourneyPlan(JourneyPlanBookResultModel model);

    }
}
