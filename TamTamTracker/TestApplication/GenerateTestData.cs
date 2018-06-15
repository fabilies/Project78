using Nager.Date;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApplication
{
    public class GenerateTestData
    {
        private Random gen = new Random();
        DateTime GetRandomDate()
        {
            DateTime start = new DateTime(2015, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range));
        }

        public List<string> GenerateListKwartieren()
        {
            List<string> kwartieren = new List<string>();
            kwartieren.Add("08:00");
            kwartieren.Add("08:15");
            kwartieren.Add("08:30");
            kwartieren.Add("08:45");
            kwartieren.Add("09:00");
            kwartieren.Add("09:15");
            kwartieren.Add("09:30");
            kwartieren.Add("09:45");
            kwartieren.Add("10:00");
            kwartieren.Add("10:15");
            kwartieren.Add("10:30");
            kwartieren.Add("10:45");
            kwartieren.Add("11:00");
            kwartieren.Add("11:15");
            kwartieren.Add("11:30");
            kwartieren.Add("11:45");
            kwartieren.Add("12:00");
            kwartieren.Add("12:00");
            kwartieren.Add("12:15");
            kwartieren.Add("12:30");
            kwartieren.Add("12:45");
            kwartieren.Add("13:00");
            kwartieren.Add("13:15");
            kwartieren.Add("13:30");
            kwartieren.Add("13:45");
            kwartieren.Add("14:00");
            kwartieren.Add("14:15");
            kwartieren.Add("14:30");
            kwartieren.Add("14:45");
            kwartieren.Add("15:00");
            kwartieren.Add("15:15");
            kwartieren.Add("15:30");
            kwartieren.Add("15:45");
            kwartieren.Add("16:00");
            kwartieren.Add("16:15");
            kwartieren.Add("16:30");
            kwartieren.Add("16:45");
            kwartieren.Add("17:00");
            return kwartieren;
        }

        public void Run()
        {
            Random rnd = new Random();
            int schoolvakantie = rnd.Next(0, 1);
            int file = rnd.Next(0, 1);
            DateTime maand_jaar = GetRandomDate();
            List<string> kwartieren = GenerateListKwartieren();
            string module = "lunch";
            int keuze = 0;
            DB.OpenCon();
            DateTime d;
            string convert_maand = "";
            int amount_of_people = 0;
            int max = 50000;
            for (int i = 0; i < max; i++)
            {

                // After save generate_new_ids    
                schoolvakantie = rnd.Next(0, 2);
                file = rnd.Next(0, 2);
                maand_jaar = GetRandomDate();
                kwartieren = GenerateListKwartieren();
                keuze = rnd.Next(0, kwartieren.Count());
                kwartieren.ElementAt(keuze);

                var temp = kwartieren[keuze];

                maand_jaar = maand_jaar.Add(TimeSpan.Parse(temp));

                convert_maand = String.Format("{0:yyyy-MM-dd:HH:mm}", maand_jaar);
                int hours = maand_jaar.Hour;

                if ((hours >= 8 && hours <= 10) || (hours) == 18 || (hours == 17))
                {
                    file = 1;
                    amount_of_people = rnd.Next(0, 20);
                }
                else
                {
                    file = 0;
                    amount_of_people = rnd.Next(20, 50);
                }

                if (DateSystem.IsPublicHoliday(maand_jaar, CountryCode.NL))
                {
                    schoolvakantie = 1;
                }
                else
                {
                    schoolvakantie = 0;
                }
                Console.WriteLine("Record verwerkt" + i + "/ " + max);
                DB.QueryInsert<string>("INSERT INTO  data_beacon(school_holiday,`file`,`dt_created`,`module`,`amount_of_people`) VALUES " +
                    "(" + schoolvakantie + "," + file + ",'" + convert_maand + "','" + module + "', " + amount_of_people + ")"); // Save results in DB
            }
            DB.CloseCon();
        }
    }
}