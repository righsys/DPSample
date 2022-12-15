namespace DPSample.Utilities.DateTimeHelper
{
    public interface IDateTimeHelper
    {
        string GetPersianDate();
        string GetPersianDate(DateTime? date);
        string GetPersianDateTime(DateTime? date);
        string GetPersianTime();
        string GetPersianTime(DateTime? date);
        string GetPersianTimeWithoutSecound(DateTime? date);
        DateTime GetLocalDateTime();
        string GetFormattedLocalDate();
        string GetPersianDateForFolderName();
        string GetTimePartInDateTime(DateTime date);
        DateTime ConvertShamsiToMiladi(string date);
    }
}
