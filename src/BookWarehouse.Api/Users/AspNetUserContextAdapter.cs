using System.Security.Claims;
using BookWarehouse.Domain;
using Microsoft.AspNetCore.Http;

namespace BookWarehouse.Api.Users
{
    public class AspNetUserContextAdapter : IUserContext
    {
        private static readonly HttpContextAccessor Accessor = new HttpContextAccessor();

        public string Username => Accessor.HttpContext?.User?.Identity?.Name;

        public bool IsInRole(string role)
        {
            return Accessor.HttpContext?.User?.IsInRole(role) ?? false;
        }
    }
}