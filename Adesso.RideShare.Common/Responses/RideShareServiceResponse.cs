using System.Collections.Generic;

namespace Adesso.RideShare.Common.Responses
{
    public class RideShareServiceResponse<T> : RideShareServiceResponse
    {
        public List<T> Result { get; set; }
    }

    public class RideShareServiceResponse
    {
        public string ErrorText { get; set; }

        public string SuccessText { get; set; }
    }
}
