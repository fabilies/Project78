using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microcharts;
using Entry = Microcharts.Entry;
using SkiaSharp;
using TamTamTracker;

namespace App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : ContentPage
    {

        List<Entry> entries = new List<Entry>
        {
            // TODO vullen via API
                //new Entry(40)
                //{
                //    Label = "Maandag",
                //    ValueLabel = "40",
                //    Color = SKColor.Parse("#FF0080")
                //},
                //new Entry(60)
                //{
                //    Label = "Dinsdag",
                //    ValueLabel = "60",
                //    Color = SKColor.Parse("#FF8C00")
                //},
                //new Entry(70)
                //{
                //    Label = "Woensdag",
                //    ValueLabel = "70",
                //    Color = SKColor.Parse("#40E0D0"),TextColor = SKColor.Parse("#000000")
                //},
                //new Entry(100)
                //{
                //    Label = "Donderdag",
                //    ValueLabel = "100",
                //    Color = SKColor.Parse("#4060e0"),TextColor = SKColor.Parse("#000000")
                //},
                //new Entry(30)
                //{
                //    Label = "Vrijdag",
                //    ValueLabel = "30",
                //    Color = SKColor.Parse("#9240e0"),TextColor = SKColor.Parse("#000000")
                //},
        };


        public Page2()
        {
            if (entries == null)
            {
                throw new Exception("No data found!");
            }
            InitializeComponent();
            // TODO set MaxValue to total amount of employees * 5 days?
            LunchChart.Chart = new BarChart { Entries = entries, MaxValue = 100, LabelTextSize = 20 };
            LunchChartLine.Chart = new LineChart { Entries = entries, MaxValue = 100, LabelTextSize = 20 };

            string apiResult = API_.getSuggestion();
            // Stap 1 -> Verwijder alle backslashes in een string
            // Stap 2 -> Per komma element eruit halen
            // Stap 3 -> Nieuwe lijst met druktes en itereren
            List<int> predictedAmount = new List<int>(); //
            string newResult = apiResult.Replace("\"", "");
            newResult = newResult.Replace('"', ' ').Trim();
            string[] values = newResult.Split(',');
            for (int i = 0; i < values.Length - 1; i++)
            {
                predictedAmount.Add(Convert.ToInt32(values[i].Trim()));
            }

            int test = predictedAmount[0]; //1e element // 8 uur


            int startTime = 8;

            var random = new Random();

            foreach (int pred in predictedAmount)
            {
                var color = String.Format("#{0:X6}", random.Next(0x1000000));

                entries.Add(new Entry(pred) {
                    Label = startTime.ToString(),
                    ValueLabel = pred.ToString(),
                    Color = SKColor.Parse(color),
                });
                startTime++;
            }

            string b = "";

            //string test = API.GetSuggestion("http://localhost:50798/api/suggestions/getSuggestion");


            // TODO compare current time to closest upcoming times and show data for upcoming time
            //var time = DateTime.Now;
            //var hm = new DateTime(time.Year, time.Month, time.Day, time.Hour, time.Minute, 0);

            //if (time.Hour >= 5)
            //{
            //    // Do nothing
            //}
            //else
            //{
            //    //Do nothing
            //}

        }

        //public void getSuggestion()
        //{
        //   var suggestion =  API.Get<string>("http://localhost:50798/api/suggestions/getsuggestion");
        //   string test = "";
        //}

    }
}