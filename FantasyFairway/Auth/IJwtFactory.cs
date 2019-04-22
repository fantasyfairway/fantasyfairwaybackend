using System.Security.Claims;
using System.Threading.Tasks;
using FantasyFairway.Data;

namespace FantasyFairway.Auth
{
    public interface IJwtFactory
    {
        Task<string> GenerateEncodedToken(string userName, ClaimsIdentity identity);
        ClaimsIdentity GenerateClaimsIdentity(string userName, string id, string role);
    }
}