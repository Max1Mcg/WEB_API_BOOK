using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WEB_API_BOOK.DbModels;

namespace WEB_API_BOOK.DbContext
{
    public class ApplicationDbContext: IdentityDbContext<UserDbModel>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}
