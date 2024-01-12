using Subasi.CustomerMS.API.Core.Domain.Abstract;

namespace Subasi.CustomerMS.API.Core.Domain.Concrete
{
    public class AppRole : BaseEntity
    {
        public string? Definition { get; set; }

        public List<AppUser>? AppUsers { get; set; }
    }
}
