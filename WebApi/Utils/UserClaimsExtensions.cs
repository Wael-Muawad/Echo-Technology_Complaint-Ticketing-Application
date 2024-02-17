namespace WebApi.Utils
{
    public static class UserClaimsExtensions
    {
        public static string GetUserId(this HttpContext httpContext)
        {
            if (httpContext is null)
            {
                return string.Empty;
            }
            var userID = httpContext.User.Claims.Single(u => u.Type == "userid");
            return userID.Value;
        }
    }
}
