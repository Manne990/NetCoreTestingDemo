using TestingDemo.Model;
using TestingDemo.Service;

namespace TestingDemo.ViewModel
{
    public interface IShowProfileViewModel
    {
        Profile CurrentProfile { get; }

        void LoadProfile();
        void SaveProfile();
    }

    public class ShowProfileViewModel : IShowProfileViewModel
    {
        private readonly IProfileService _profileService;

        public ShowProfileViewModel(IProfileService profileService)
        {
            _profileService = profileService;
        }

        public Profile CurrentProfile { get; private set; }

        public void LoadProfile()
        {
            if (_profileService.HasProfile() == false)
            {
                CurrentProfile = new Profile();
                return;
            }

            CurrentProfile = _profileService.GetProfile();
        }

        public void SaveProfile()
        {
            _profileService.SaveProfile(CurrentProfile);
        }
    }
}