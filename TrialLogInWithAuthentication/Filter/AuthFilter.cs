using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace TrialLogInWithAuthentication.Filter
{
    public class AuthFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.Session.Get("LogSession") == null)
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}
