using System;

namespace TestingDemo.Model
{
    public class Profile
    {
        public Profile()
        {
            Gender = DefaultGender();
            BirthDate = DefaultBirthDate();
            PhysicalActivity = DefaultPhysicalActivity();
        }

        public GenderTypes Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public PhysicalActivityTypes PhysicalActivity { get; set; }

        public int Age
        {
            get
            {
                var end = DateTime.Now;
                return (end.Year - BirthDate.Year - 1) + (((end.Month > BirthDate.Month) || ((end.Month == BirthDate.Month) && (end.Day >= BirthDate.Day))) ? 1 : 0);
            }
        }

        public double CalculateDailyEnergyIntake()
        {
            if (Weight <= 0 || Height <= 0)
            {
                return 0;
            }

            var dateDiff = DateTime.Now - BirthDate;
            var age = (double)((new DateTime(1, 1, 1) + dateDiff).Year - 1);

            // Harris-Benedict Equation
            // https://www.livestrong.com/article/178764-caloric-intake-formula/
            if (Gender == GenderTypes.Male)
            {
                return (66.4730 + (13.7516 * Weight) + (5.0033 * Height) - (6.7550 * age)) * GetActivityLevelFactor();
            }

            return (655.0955 + (9.5634 * Weight) + (1.8496 * Height) - (4.6756 * age)) * GetActivityLevelFactor();
        }

        public int CalculateDailyCarbIntake()
        {
            return (int)Math.Round(CalculateDailyEnergyIntake() * 0.65 / 4);
        }

        public int CalculateDailyFatIntake()
        {
            return (int)Math.Round(CalculateDailyEnergyIntake() / 3 / 9);
        }

        public int CalculateDailyProteinIntake()
        {
            return (int)Math.Round(CalculateDailyEnergyIntake() * 0.2 / 4);
        }

        public double CalculateRDIVitaminA()
        {
            if (Age < 2)
            {
                return 300;
            }

            if (Age < 6)
            {
                return 350;
            }

            if (Age < 10)
            {
                return 400;
            }

            if (Age < 14)
            {
                return 600;
            }

            return Gender == GenderTypes.Male ? 900 : 700;
        }

        public double CalculateRDIVitaminB2()
        {
            if (Age < 1)
            {
                return 0.5;
            }

            if (Age < 2)
            {
                return 0.6;
            }

            if (Age < 6)
            {
                return 0.7;
            }

            if (Age < 10)
            {
                return 1.1;
            }

            if (Gender == GenderTypes.Male)
            {
                if (Age < 14)
                {
                    return 1.4;
                }

                if (Age < 61)
                {
                    return 1.7;
                }

                if (Age < 75)
                {
                    return 1.5;
                }

                return 1.3;
            }

            if (Age < 14)
            {
                return 1.2;
            }

            if (Age < 61)
            {
                return 1.3;
            }

            return 1.2;
        }

        public double CalculateRDIVitaminB6()
        {
            if (Age < 1)
            {
                return 0.4;
            }

            if (Age < 2)
            {
                return 0.5;
            }

            if (Age < 6)
            {
                return 0.7;
            }

            if (Age < 10)
            {
                return 1.0;
            }

            if (Gender == GenderTypes.Male)
            {
                if (Age < 14)
                {
                    return 1.3;
                }

                return 1.6;
            }

            if (Age < 14)
            {
                return 1.1;
            }

            if (Age < 31)
            {
                return 1.3;
            }

            return 1.2;
        }

        public double CalculateRDIVitaminB12()
        {
            if (Age < 1)
            {
                return 0.5;
            }

            if (Age < 2)
            {
                return 0.6;
            }

            if (Age < 6)
            {
                return 0.8;
            }

            if (Age < 10)
            {
                return 1.3;
            }

            return 2;
        }

        public double CalculateRDIVitaminC()
        {
            if (Age < 1)
            {
                return 20;
            }

            if (Age < 2)
            {
                return 25;
            }

            if (Age < 6)
            {
                return 30;
            }

            if (Age < 10)
            {
                return 40;
            }

            if (Age < 14)
            {
                return 50;
            }

            return 75;
        }

        public double CalculateRDIVitaminD()
        {
            if (Age < 75)
            {
                return 10;
            }

            return 20;
        }

        public double CalculateRDIVitaminE()
        {
            if (Age < 1)
            {
                return 3;
            }

            if (Age < 2)
            {
                return 4;
            }

            if (Age < 6)
            {
                return 5;
            }

            if (Age < 10)
            {
                return 6;
            }

            if (Gender == GenderTypes.Male)
            {
                if (Age < 14)
                {
                    return 8;
                }

                return 10;
            }

            if (Age < 14)
            {
                return 7;
            }

            return 8;
        }

        public double CalculateRDIIron()
        {
            if (Age < 14)
            {
                return 11;
            }

            if (Gender == GenderTypes.Male)
            {
                if (Age < 17)
                {
                    return 11;
                }

                return 9;
            }

            if (Age < 61)
            {
                return 15;
            }

            return 9;
        }

        public double CalculateRDICalsium()
        {
            if (Age < 18)
            {
                return 900;
            }

            return 800;
        }

        public double CalculateRDICopper()
        {
            if (Age < 14)
            {
                return 0.7;
            }

            return 0.9;
        }

        public double CalculateRDIMagnesium()
        {
            if (Age < 14)
            {
                return 280;
            }

            return Gender == GenderTypes.Male ? 350 : 280;
        }

        public double CalculateRDIZinc()
        {
            if (Gender == GenderTypes.Male)
            {
                if (Age < 14)
                {
                    return 11;
                }

                if (Age < 17)
                {
                    return 12;
                }

                return 9;
            }

            if (Age < 14)
            {
                return 8;
            }

            if (Age < 17)
            {
                return 9;
            }

            return 7;
        }

        public double CalculateRDIPotassium()
        {
            if (Gender == GenderTypes.Male)
            {
                if (Age < 14)
                {
                    return 3300;
                }

                return 3500;
            }

            if (Age < 14)
            {
                return 2900;
            }

            return 3100;
        }

        public static GenderTypes DefaultGender() => GenderTypes.Female;
        public static DateTime DefaultBirthDate() => new DateTime(1980, 1, 1);
        public static PhysicalActivityTypes DefaultPhysicalActivity() => PhysicalActivityTypes.Moderate;

        private double GetActivityLevelFactor()
        {
            switch (PhysicalActivity)
            {
                case PhysicalActivityTypes.NotActiveAtAll:
                    return 1.2;
                case PhysicalActivityTypes.SlightlyActive:
                    return 1.375;
                case PhysicalActivityTypes.Moderate:
                    return 1.55;
                case PhysicalActivityTypes.Active:
                    return 1.725;
                case PhysicalActivityTypes.VeryActive:
                    return 1.9;
            }

            return 1;
        }
    }

    public enum GenderTypes
    {
        Male,
        Female
    }

    public enum PhysicalActivityTypes
    {
        NotActiveAtAll,
        SlightlyActive,
        Moderate,
        Active,
        VeryActive
    }
}