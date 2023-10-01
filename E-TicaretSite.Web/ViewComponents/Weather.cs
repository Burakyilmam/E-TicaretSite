using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Threading.Tasks;

public class Weather : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        string api = "0928835605ea3e6b03f3a11f83b9d751";
        string city = "Bursa";
        string baseUrl = "https://api.openweathermap.org/data/2.5/weather";

        using (HttpClient client = new HttpClient())
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"{baseUrl}?q={city}&appid={api}");

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    JObject json = JObject.Parse(content);
                    double kelvinTemperature = json["main"]["temp"].Value<double>();
                    double celsiusTemperature = kelvinTemperature - 273.15;
                    string iconCode = json["weather"][0]["icon"].Value<string>();
                    string iconUrl = $"http://openweathermap.org/img/w/{iconCode}.png";
                    ViewBag.IconUrl = iconUrl;
                    ViewBag.Temperature = celsiusTemperature.ToString("0");
                    ViewBag.City = json["name"];
                }
                else
                {

                }
            }
            catch (Exception ex)
            {

            }
        }

        return View();
    }
}
