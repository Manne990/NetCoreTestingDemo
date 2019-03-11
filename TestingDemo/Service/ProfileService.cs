using TestingDemo.Model;
using TestingDemo.Repository;

namespace TestingDemo.Service
{
    public interface IProfileService
    {
        void SaveProfile(Profile profile);
        Profile GetProfile();
        bool HasProfile();
    }

    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _profileRepository;

        public ProfileService(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }

        public Profile GetProfile()
        {
            return _profileRepository?.GetProfile();
        }

        public bool HasProfile()
        {
            return _profileRepository?.GetProfile() != null;
        }

        public void SaveProfile(Profile profile)
        {
            _profileRepository?.SaveProfile(profile);
        }
    }
}