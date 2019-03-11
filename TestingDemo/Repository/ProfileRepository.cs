using TestingDemo.Model;

namespace TestingDemo.Repository
{
    public interface IProfileRepository
    {
        Profile GetProfile();
        void SaveProfile(Profile profile);
    }

    public class ProfileRepository : IProfileRepository
    {
        private Profile _profile;

        public ProfileRepository(Profile profile)
        {
            _profile = profile;
        }

        public Profile GetProfile()
        {
            return _profile;
        }

        public void SaveProfile(Profile profile)
        {
            _profile = profile;
        }
    }
}
