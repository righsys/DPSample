using DPSample.Utilities.DateTimeHelper;

namespace DPSample.SharedServices.Common
{
    public class ApplicationServiceBase
    {
        public IDateTimeHelper _dateTimeHelper;
        public ApplicationServiceBase(IDateTimeHelper dateTimeHelper)
        {
            _dateTimeHelper = dateTimeHelper;
        }
    }
}