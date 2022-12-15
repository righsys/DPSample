namespace DPSample.Utilities.Security
{
    public interface ISecurityServices
    {
        string CreateRandomSalt();
        string CreatePasswordHash(string password, string salt);
    }
}