using System;
using NUnit.Framework;
using TestingDemo.Model;

namespace TestingDemo.Test
{
    [TestFixture]
    public class TestProfileCalculations
    {
        private Profile _maleProfile;
        private Profile _femaleProfile;

        [SetUp]
        public void SetUp()
        {
            _maleProfile = new Profile
            {
                BirthDate = DateTime.Now.AddYears(-47),
                Gender = GenderTypes.Male,
                Weight = 105,
                Height = 183,
                PhysicalActivity = PhysicalActivityTypes.Moderate
            };

            _femaleProfile = new Profile
            {
                BirthDate = DateTime.Now.AddYears(-42),
                Gender = GenderTypes.Female,
                Weight = 55,
                Height = 168,
                PhysicalActivity = PhysicalActivityTypes.SlightlyActive
            };
        }

        [Test]
        public void TestCalculateDailyEnergyIntakeMale()
        {
            // ARRANGE

            // ACT
            var result = (int)Math.Round(_maleProfile.CalculateDailyEnergyIntake());

            // ASSERT
            Assert.AreEqual(3268, result);
        }

        [Test]
        public void TestCalculateDailyEnergyIntakeFemale()
        {
            // ARRANGE

            // ACT
            var result = (int)Math.Round(_femaleProfile.CalculateDailyEnergyIntake());

            // ASSERT
            Assert.AreEqual(1781, result);
        }

        [Test]
        public void TestCalculateDailyCarbIntakeMale()
        {
            // ARRANGE

            // ACT
            var result = _maleProfile.CalculateDailyCarbIntake();

            // ASSERT
            Assert.AreEqual(531, result);
        }

        [Test]
        public void TestCalculateDailyCarbIntakeFemale()
        {
            // ARRANGE

            // ACT
            var result = _femaleProfile.CalculateDailyCarbIntake();

            // ASSERT
            Assert.AreEqual(289, result);
        }

        [Test]
        public void TestCalculateDailyProteinIntakeMale()
        {
            // ARRANGE

            // ACT
            var result = _maleProfile.CalculateDailyProteinIntake();

            // ASSERT
            Assert.AreEqual(163, result);
        }

        [Test]
        public void TestCalculateDailyProteinIntakeFemale()
        {
            // ARRANGE

            // ACT
            var result = _femaleProfile.CalculateDailyProteinIntake();

            // ASSERT
            Assert.AreEqual(89, result);
        }

        [Test]
        public void TestCalculateDailyFatIntakeMale()
        {
            // ARRANGE

            // ACT
            var result = _maleProfile.CalculateDailyFatIntake();

            // ASSERT
            Assert.AreEqual(121, result);
        }

        [Test]
        public void TestCalculateDailyFatIntakeFemale()
        {
            // ARRANGE

            // ACT
            var result = _femaleProfile.CalculateDailyFatIntake();

            // ASSERT
            Assert.AreEqual(66, result);
        }
    }
}