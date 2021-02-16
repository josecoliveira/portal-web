using PortalWebServer.Models;

namespace PortalWebServer.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}