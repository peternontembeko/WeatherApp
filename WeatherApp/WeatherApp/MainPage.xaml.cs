using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherData;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace WeatherApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
       protected override async void OnAppearing()
       {
            base.OnAppearing();
            await GetOpenWeatherData();
        }
        private async Task GetOpenWeatherData() 
        {
            var location = await Geolocation.GetLocationAsync();

            double latitude = location.Latitude;
            double longitude = location.Longitude;
            
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add("Accept", "application/json");
            string url =  $"https://api.openweathermap.org/data/2.5/weather?lat=35&lon=139&appid=2ba935debc178e093e33fc31bab59018";
            string response = await client.GetStringAsync(url);

            OpenWeatherData data = JsonConvert.DeserializeObject<OpenWeatherData>(response);

            BindingContext = data;



        }
    }
}
