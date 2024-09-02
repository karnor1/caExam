using CaExam.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CaExam.Helpers
{
    namespace CaExam.Helpers
    {
        public class UserValidationHelper
        {
            public static IActionResult GetUserGuid(ClaimsPrincipal principal, out Guid guid)
            {
                guid = Guid.Empty; 

                var userIdClaim = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (userIdClaim == null)
                {
                    return new UnauthorizedObjectResult("INVALID TOKEN - User ID not found in token.");
                }

                if (!Guid.TryParse(userIdClaim, out guid))
                {
                    return new BadRequestObjectResult("INVALID TOKEN - Invalid User ID in token.");
                }

                return null; // no issues 
            }


            public static IActionResult GetUserRole(ClaimsPrincipal principal, out eUserRole role)
            {
                role = eUserRole.Guest;

                var userIdClaim = principal.FindFirst(ClaimTypes.Role)?.Value;

                if (userIdClaim == null)
                {
                    return new UnauthorizedObjectResult("INVALID TOKEN - User ID not found in token.");
                }

                if (!eUserRole.TryParse(userIdClaim, out role))
                {
                    return new BadRequestObjectResult("INVALID TOKEN - Invalid User ID in token.");
                }

                return null; // no issues 
            }
        }
    }
}
