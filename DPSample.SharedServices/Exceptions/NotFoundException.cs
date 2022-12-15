namespace DPSample.SharedServices.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name, object key)
            : base($"موجودیت \"{name}\" با مشخصه ({key}) یافت نشد.")
        {
        }
    }
}