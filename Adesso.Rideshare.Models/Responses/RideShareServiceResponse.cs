using System.Collections.Generic;

namespace Adesso.RideShare.Common.Models.Responses
{
    public class RideShareServiceResponse<T> : RideShareServiceResponse
    {
        public T Result { get; set; }
    }

    public class RideShareServiceResponse
    {
        public string ErrorText { get; set; }

        public string SuccessText { get; set; }
    }
}
