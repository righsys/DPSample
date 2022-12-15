namespace DPSample.Utilities.DateTimeHelper
{
    public class DateTimeHelper : IDateTimeHelper
    {
        FarsiDate _farsiDate = new FarsiDate();
        ShamsiToMiladi _shamsiToMiladi = new ShamsiToMiladi();

        public System.DateTime GetLocalDateTime()
        {
            _farsiDate.getPersianDate(System.DateTime.UtcNow);
            //if (_farsiDate.Month >= 1 && _farsiDate.Month <= 6)
            //{
            //    return DateTime.UtcNow.AddHours(4.5);
            //}
            return System.DateTime.UtcNow.AddHours(3.5);
        }
        public System.DateTime GetLocalDate()
        {
            System.DateTime dateTime = GetLocalDateTime();
            string d = dateTime.Year + "/" + dateTime.Month + "/" + dateTime.Day;
            return System.DateTime.Parse(d);
        }
        public string GetFormattedLocalDate()
        {
            System.DateTime dateTime = GetLocalDateTime();
            string d = dateTime.Year + "/" + dateTime.Month + "/" + dateTime.Day;
            return d;
        }
        public TimeSpan GetLocalTime()
        {
            System.DateTime currentDate = GetLocalDateTime();
            _farsiDate.getPersianDate(currentDate);
            return TimeSpan.Parse(string.Format("{0:D2}:{1:D2}:{2:D2}", currentDate.Hour, currentDate.Minute, currentDate.Second));
        }
        public string GetPersianDate()
        {
            System.DateTime currentDate = GetLocalDateTime();
            _farsiDate.getPersianDate(currentDate);
            return string.Format("{0:D2}/{1:D2}/{2:D2}", _farsiDate.Year, _farsiDate.Month, _farsiDate.Day);
        }
        public string GetPersianDateForFolderName()
        {
            System.DateTime currentDate = GetLocalDateTime();
            _farsiDate.getPersianDate(currentDate);
            return string.Format("{0:D2}-{1:D2}-{2:D2}", _farsiDate.Year, _farsiDate.Month, _farsiDate.Day);
        }
        public string GetPersianDate(System.DateTime? date)
        {
            if (date != null)
            {
                _farsiDate.getPersianDate(date.Value);
                return string.Format("{0:D2}/{1:D2}/{2:D2}", _farsiDate.Year, _farsiDate.Month, _farsiDate.Day);
            }
            return "";
        }
        public string GetPersianDateTime(System.DateTime? date)
        {
            if (date != null)
            {
                _farsiDate.getPersianDate(date.Value);

                return string.Format("{3}-{0:D2}/{1:D2}/{2:D2}", _farsiDate.Year, _farsiDate.Month, _farsiDate.Day, GetTimePartInDateTime(date.Value));
            }
            return "";
        }
        public string GetPersianTime()
        {
            System.DateTime currentDate = GetLocalDateTime();
            _farsiDate.getPersianDate(currentDate);
            return string.Format("{0:D2}:{1:D2}:{2:D2}", currentDate.Hour, currentDate.Minute, currentDate.Second);
        }
        public string GetPersianTimeWithMilisecound()
        {
            System.DateTime currentDate = GetLocalDateTime();
            _farsiDate.getPersianDate(currentDate);
            return string.Format("{0:D2}:{1:D2}:{2:D2}.{3:D3}", currentDate.Hour, currentDate.Minute, currentDate.Second, currentDate.Millisecond);
        }
        public string GetPersianTime(System.DateTime? date)
        {
            if (date != null)
            {
                return string.Format("{0:D2}:{1:D2}:{2:D2}", date.Value.Hour, date.Value.Minute, date.Value.Second);
            }
            else
            {
                System.DateTime currentDate;
                _farsiDate.getPersianDate(date.Value);
                if (_farsiDate.Month >= 1 && _farsiDate.Month <= 6)
                {
                    currentDate = System.DateTime.UtcNow.AddHours(3.5);
                }
                else
                {
                    currentDate = System.DateTime.UtcNow.AddHours(3.5);
                }
                return string.Format("{0:D2}:{1:D2}:{2:D2}", currentDate.Hour, currentDate.Minute, currentDate.Second);
            }
        }
        public string GetPersianTimeWithoutSecound(System.DateTime? date)
        {
            if (date != null)
            {
                return string.Format("{0:D2}:{1:D2}", date.Value.Hour, date.Value.Minute);
            }
            else
            {
                System.DateTime currentDate;
                _farsiDate.getPersianDate(date.Value);
                if (_farsiDate.Month >= 1 && _farsiDate.Month <= 6)
                {
                    currentDate = System.DateTime.UtcNow.AddHours(3.5);
                }
                else
                {
                    currentDate = System.DateTime.UtcNow.AddHours(3.5);
                }
                return string.Format("{0:D2}:{1:D2}", currentDate.Hour, currentDate.Minute);
            }
        }
        public string GetTimePartInDateTime(System.DateTime date)
        {
            return string.Format("{0:D2}:{1:D2}:{2:D2}", date.Hour, date.Minute, date.Second);
        }
        public System.DateTime ConvertShamsiToMiladi(string date)
        {
            return _shamsiToMiladi.shamsitomiladi(date);
        }
    }
}