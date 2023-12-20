namespace AuthAPI.Service
{
    public interface ITokenGenerator
    {
        string GenerateToken(string email, string role);
    }
}