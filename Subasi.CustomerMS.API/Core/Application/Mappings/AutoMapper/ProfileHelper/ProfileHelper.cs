using AutoMapper;

namespace Subasi.CustomerMS.API.Core.Application.Mappings.AutoMapper.ProfileHelper
{
    public static class ProfileHelper
    {
        public static List<Profile> GetProfiles()
        {
            return new List<Profile>
            {
                new CustomerProfile(),
                new AddressProfile(),
                new AppUserProfile()
            };
        }
    }
}
