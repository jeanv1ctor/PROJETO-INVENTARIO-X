using System.Security.Claims;

namespace Api_Inventario.Extensions
{
    public static class RoleClaimExtensions
    {

        public static IEnumerable<Claim> GetClaims(this UserModel user)
        {

            var result = new List<Claim>
            {
                new(ClaimTypes.Email, user.Email)
            };

            result.AddRange(user.Roles.Select(role => new Claim(ClaimTypes.Role, role.Name)));
          
            return result;
        }
    }
}
