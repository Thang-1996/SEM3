using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using ACC_Weather.Models;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ACC_Weather
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        ObservableCollection<WeatherJSON> WeatherEachHours;
        ObservableCollection<DailyForecast> WeatherEachDays;

        public MainPage()
        {
            this.InitializeComponent();
            WeatherEachHours = new ObservableCollection<WeatherJSON>();
            InitJSON();
            WeatherEachDays = new ObservableCollection<DailyForecast>();
            InitEachDaysJSON();
        }

        private async void InitJSON()
        {
            var url = "http://dataservice.accuweather.com/forecasts/v1/hourly/12hour/353412?apikey=93Qg780lHwYM4SO58n7DFPLqHg4oKADn&language=vi-vn&metric=true";
            var list = await WeatherJSON.GetJSON(url) as List<WeatherJSON>;
            Debug.WriteLine("Count:" + list.Count);
            list.ForEach(it =>
            {
                var match = Regex.Matches(it.DateTime, "T(?<time>\\d+):")[0].Groups["time"].Value;
                if (int.Parse(match) > 12)
                {
                    match = (int.Parse(match) - 12) + "PM";
                }
                else
                {
                    match += "PM";
                }

                it.DateTime = match;
                it.Temperature.Value += "\u00B0";
                it.WeatherIcon = string.Format("https://vortex.accuweather.com/adc2010/images/slate/icons/{0}.svg",
                    it.WeatherIcon);
                WeatherEachHours.Add(it);

            });
            WeatherDescriptionTextBlock.Text = list[0].IconPhrase;
            WeatherTemperatureTextBlock.Text = list[0].Temperature.Value;
        }

        private async void InitEachDaysJSON()
        {
            var urlFiveDay = "http://dataservice.accuweather.com/forecasts/v1/daily/5day/353412?apikey=93Qg780lHwYM4SO58n7DFPLqHg4oKADn&language=vi-vn&metric=true";
            var obj = await WeatherEachDay.GetWeatherEach(urlFiveDay) as WeatherEachDay;
            obj.DailyForecasts.ForEach(it =>
            {
                var matchs = Regex.Matches(it.Date, "\\d+");
                var date = new DateTime(int.Parse(matchs[0].Value),int.Parse(matchs[1].Value),int.Parse(matchs[2].Value));
                it.Date = date.DayOfWeek.ToString();
                it.Day.Icon = string.Format("https://vortex.accuweather.com/adc2010/images/slate/icon/{0}.svg",
                    it.Day.Icon);
                Debug.WriteLine("Binh : " + it.Date);
                WeatherEachDays.Add(it);

            });
            Today.Text = WeatherEachDays[0].Date + "  Today";
            MaxTemperature.Text = WeatherEachDays[0].Temperature.Maximum.Value + "";
            MinTemperature.Text = WeatherEachDays[0].Temperature.Minimum.Value + "";
            WeatherEachDays.RemoveAt(0);
        }
    }
}
