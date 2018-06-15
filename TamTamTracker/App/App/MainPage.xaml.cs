using App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App
{
    public partial class MainPage : ContentPage
    {
        public void ClickTap1(object sender, EventArgs e)
        {
            var page = new Page1();
            MainView.Content = page.Content;
        }

        public void ClickTap2(object sender, EventArgs e)
        {
            var page = new Page2();
            MainView.Content = page.Content;
        }

        public void ClickTap3(object sender, EventArgs e)
        {
            var page = new Page3();
            MainView.Content = page.Content;
        }

        public void ClickTap4(object sender, EventArgs e)
        {
            var page = new Page4();
            MainView.Content = page.Content;
            MainView.ControlTemplate = page.ControlTemplate;
        }

        public MainPage()
        {
            InitializeComponent();
        }
    }
}
