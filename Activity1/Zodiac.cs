using System;

namespace CSharp.Activity.Profile
{
    /// <summary>
    ///	Definition of Zodiac sign class.
    /// </summary>
    public class Zodiac
    {
        // Static instances of zodiacs signs
        public static Zodiac ARIES = new Zodiac(3, 21, 4, 19, "Aries");
        public static Zodiac TAURUS = new Zodiac(4, 20, 5, 20, "Taurus");
        public static Zodiac GEMINI = new Zodiac(5, 21, 6, 20, "Gemini");
        public static Zodiac CANCER = new Zodiac(6, 21, 7, 22, "Cancer");
        public static Zodiac LEO = new Zodiac(7, 23, 8, 22, "Leo");
        public static Zodiac VIRGO = new Zodiac(8, 23, 9, 22, "Virgo");
        public static Zodiac LIBRA = new Zodiac(9, 23, 10, 22, "Libra");
        public static Zodiac SCORPIO = new Zodiac(10, 23, 11, 21, "Scorpio");
        public static Zodiac SAGITTARIUS = new Zodiac(11, 22, 12, 21, "Sagittarius");
        public static Zodiac CAPRICORN = new Zodiac(12, 22, 1, 19, "Capricorn");
        public static Zodiac AQUARIUS = new Zodiac(1, 20, 2, 18, "Aquarius");
        public static Zodiac PISCES = new Zodiac(2, 19, 3, 20, "Pisces");


        /// <summary>
        /// Property to return the Start Date
        /// </summary>
        public int StartDate { get; private set; }


        /// <summary>
        /// Property to return the End Date
        /// </summary>
        public int EndDate { get; private set; }


        /// <summary>
        /// Property to return the Start Month
        /// </summary>
        public int StartMonth { get; private set; }


        /// <summary>
        /// Property to return the End Month
        /// </summary>
        public int EndMonth { get; private set; }


        /// <summary>
        /// Property to return the zodiac Star Sign name
        /// </summary>
        public string StarSign { get; private set; }


        /// <summary>
        /// Constructor to initialize the zodiac objects.
        /// </summary>
        /// <param name="startMonth">start month</param>
        /// <param name="startDate">start date</param>
        /// <param name="endMonth">end month</param>
        /// <param name="endDate">end date</param>
        /// <param name="starSign">zodiac star sign</param>
        private Zodiac(int startMonth, int startDate, int endMonth, int endDate, string starSign)
        {
            this.StartMonth = startMonth;
            this.StartDate = startDate;
            this.EndMonth = endMonth;
            this.EndDate = endDate;
            this.StarSign = starSign;
        }


        /// <summary>
        /// Method to accept the birth date and return the corresponding Zodiac sign
        /// </summary>
        /// <param name="birthDate">Birth Date</param>
        /// <returns></returns>
        public static Zodiac GetZodiacSign(DateTime birthDate)
        {
            #region Activity 1.1
            // TODO: Given the birth date, return the corresponding
            // zodiac sign or null if the date does not have a corresponding zodiac sign.
            // Refer to the constants above for the zodiac sign values.
            // You may declare additional local variables if necessary to accomplish this activity.
            // HINT: Make use of the 'return' keyword

            int month = birthDate.Month;  // month of birth
            int day = birthDate.Day;      // date of birth

            /*My long way solution
            if (month == 12)
            {
                if (day < 22)
                    return SAGITTARIUS;
                else
                    return CAPRICORN;
            }
            else if (month == 1)
            {
                if (day < 20)
                    return CAPRICORN;
                else
                    return AQUARIUS;
            }
            else if (month == 2)
            {
                if (day < 19)
                    return AQUARIUS;
                else
                    return PISCES;
            }
            else if (month == 3)
            {
                if (day < 21)
                    return PISCES;
                else
                    return ARIES;
            }
            else if (month == 4)
            {
                if (day < 20)
                    return ARIES;
                else
                    return TAURUS;
            }
            else if (month == 5)
            {
                if (day < 21)
                    return TAURUS;
                else
                    return GEMINI;
            }
            else if (month == 6)
            {
                if (day < 21)
                    return GEMINI;
                else
                    return CANCER;
            }
            else if (month == 7)
            {
                if (day < 23)
                    return CANCER;
                else
                    return LEO;
            }
            else if (month == 8)
            {
                if (day < 23)
                    return LEO;
                else
                    return VIRGO;
            }
            else if (month == 9)
            {
                if (day < 23)
                    return VIRGO;
                else
                    return LIBRA;
            }
            else if (month == 10)
            {
                if (day < 23)
                    return LIBRA;
                else
                    return SCORPIO;
            }
            else if (month == 11)
            {
                if (day < 22)
                    return SCORPIO;
                else
                    return SAGITTARIUS;
            }
            */
            foreach (Zodiac zodiac in new Zodiac[] {
                ARIES, TAURUS, GEMINI,
                CANCER, LEO, VIRGO,
                LIBRA, SCORPIO, SAGITTARIUS,
                CAPRICORN, AQUARIUS, PISCES
            })
            {
                if (month == zodiac.StartMonth && day >= zodiac.StartDate)
                {
                    return zodiac;
                }
                if (month == zodiac.EndMonth && day <= zodiac.EndDate)
                {
                    return zodiac;
                }
            }

            #endregion

            return null; // default behaviour
        }
    }
}