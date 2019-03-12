using System;
using Autofac;
using NSubstitute;
using NUnit.Framework;
using TestingDemo.Model;
using TestingDemo.Repository;
using TestingDemo.Service;
using TestingDemo.ViewModel;

namespace TestingDemo.Test
{
    [TestFixture]
    public class TestShowProfileViewModel
    {
        private IProfileRepository _profileRepository;
        private IProfileService _profileService;
        private IShowProfileViewModel _subject;

        [SetUp]
        public void SetUp()
        {
            // Create the builder
            var builder = new ContainerBuilder();

            // Register a mock instance for IProfileRepository
            _profileRepository = Substitute.For<IProfileRepository>();
            builder.RegisterInstance(_profileRepository)?.As<IProfileRepository>()?.SingleInstance();

            // Register a mock instance for IProfileService
            _profileService = Substitute.For<IProfileService>();
            builder.RegisterInstance(_profileService)?.As<IProfileService>()?.SingleInstance();

            // Register the subject
            builder.RegisterType<ShowProfileViewModel>()?.As<IShowProfileViewModel>()?.SingleInstance();

            // Build the IoC container
            var container = builder.Build();

            // Resolve the subject instance
            _subject = container.Resolve<IShowProfileViewModel>();
        }

        [Test]
        public void TestLoadProfileWithEmptyProfile()
        {
            // ARRANGE
            _profileService.HasProfile().Returns(false);

            // ACT
            _subject.LoadProfile();

            // ASSERT
            Assert.NotNull(_subject.CurrentProfile);

            Assert.AreEqual(Profile.DefaultGender(), _subject.CurrentProfile.Gender);
            Assert.AreEqual(Profile.DefaultBirthDate(), _subject.CurrentProfile.BirthDate);
            Assert.AreEqual(Profile.DefaultPhysicalActivity(), _subject.CurrentProfile.PhysicalActivity);
            Assert.AreEqual(0, _subject.CurrentProfile.Weight);
            Assert.AreEqual(0, _subject.CurrentProfile.Height);
        }

        [Test]
        public void TestLoadProfileWithExistingProfile()
        {
            // ARRANGE
            var profile = new Profile
            {
                BirthDate = DateTime.Now.AddYears(-45),
                Gender = GenderTypes.Male,
                Weight = 100,
                Height = 183,
                PhysicalActivity = PhysicalActivityTypes.Moderate
            };

            _profileService.HasProfile().Returns(true);
            _profileService.GetProfile().Returns(profile);

            // ACT
            _subject.LoadProfile();

            // ASSERT
            Assert.NotNull(_subject.CurrentProfile);

            Assert.AreEqual(profile.Gender, _subject.CurrentProfile.Gender);
            Assert.AreEqual(profile.BirthDate, _subject.CurrentProfile.BirthDate);
            Assert.AreEqual(profile.PhysicalActivity, _subject.CurrentProfile.PhysicalActivity);
            Assert.AreEqual(profile.Weight, _subject.CurrentProfile.Weight);
            Assert.AreEqual(profile.Height, _subject.CurrentProfile.Height);
            Assert.AreEqual(profile.Age, _subject.CurrentProfile.Age);
            Assert.AreEqual(45, _subject.CurrentProfile.Age);
        }

        [Test]
        public void TestSaveProfile()
        {
            // ARRANGE
            Profile savedProfile = null;

            var profile = new Profile
            {
                BirthDate = DateTime.Now.AddYears(-45),
                Gender = GenderTypes.Male,
                Weight = 100,
                Height = 183,
                PhysicalActivity = PhysicalActivityTypes.Moderate
            };

            _profileService.HasProfile().Returns(true);
            _profileService.GetProfile().Returns(profile);
            _profileService.When(a => a.SaveProfile(Arg.Any<Profile>())).Do(a => 
            {
                savedProfile = a.Arg<Profile>();
            });

            _subject.LoadProfile();

            // ACT
            _subject.CurrentProfile.BirthDate = DateTime.Now.AddYears(-40);
            _subject.CurrentProfile.Gender = GenderTypes.Female;
            _subject.CurrentProfile.Weight = 90;
            _subject.CurrentProfile.Height = 184;
            _subject.CurrentProfile.PhysicalActivity = PhysicalActivityTypes.Active;

            _subject.SaveProfile();

            // ASSERT
            _profileService.Received().SaveProfile(_subject.CurrentProfile);

            Assert.NotNull(savedProfile);

            Assert.AreEqual(_subject.CurrentProfile.Gender, savedProfile.Gender);
            Assert.AreEqual(_subject.CurrentProfile.BirthDate, savedProfile.BirthDate);
            Assert.AreEqual(_subject.CurrentProfile.PhysicalActivity, savedProfile.PhysicalActivity);
            Assert.AreEqual(_subject.CurrentProfile.Weight, savedProfile.Weight);
            Assert.AreEqual(_subject.CurrentProfile.Height, savedProfile.Height);
            Assert.AreEqual(_subject.CurrentProfile.Age, savedProfile.Age);
            Assert.AreEqual(40, savedProfile.Age);
        }
    }
}