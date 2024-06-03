using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace WEB_API_BOOK.DbModels
{
    public class UserDbModel:IdentityUser
    {
        public string? Description { get; set; }
    }
}
