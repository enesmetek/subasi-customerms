using Subasi.CustomerMS.API.Core.Domain.Abstract;

namespace Subasi.CustomerMS.API.Core.Domain.Concrete
{
    public class AppUser : BaseEntity
    {
        public string Username { get; set; } = null!;
        public byte[] PasswordHash { get; set; } = null!;
        public byte[] PasswordSalt { get; set; } = null!;
        public string? RefreshToken { get; set; }
        public DateTime? TokenCreated { get; set; }
        public DateTime? TokenExpires { get; set; }

        public Guid AppRoleID { get; set; }
        public AppRole? AppRole { get; set; } 
        public string AppRoleName { get; set;} = null!;
    }
}
