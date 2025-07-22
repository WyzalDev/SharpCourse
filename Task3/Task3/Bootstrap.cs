// Copyright (c) 2012-2021 FuryLion Group. All Rights Reserved.

using System.Text;
using Task3.Data;
using Task3.Data.Weather;

namespace Task3
{
    internal class Bootstrap
    {
        public static void Main(string[] args)
        {
            Console.Clear();
            ShowMainMenu();
        }

        private static void ShowMainMenu()
        {
            var menuHint = new StringBuilder()
                .AppendLine("1. Get weather info for today")
                .AppendLine("2. Get weather info for 5 days")
                .AppendLine("\n\r0 - Exit.");

            Console.Clear();
            Console.Write(menuHint);

            var choice = DefaultInputs.GetCorrectNumberFromConsole(DefaultInputs.EnterChoice, 0, 5);

            switch (choice)
            {
                case 1:
                    ShowCityChoiceMenu(true);
                    break;
                case 2:
                    ShowCityChoiceMenu(false);
                    break;
            }
        }

        private static void ShowCityChoiceMenu(bool forToday)
        {
            var menuHint = new StringBuilder()
                .AppendLine("Choose city:")
                .AppendLine("1. Vitebsk.")
                .AppendLine("2. Moscow.")
                .AppendLine("3. London.")
                .AppendLine("4. Tokio.")
                .AppendLine("5. New York.")
                .AppendLine("6. Enter city from keyboard.")
                .AppendLine("\n\r0 - Back.");

            Console.Clear();
            Console.Write(menuHint);

            var choice = DefaultInputs.GetCorrectNumberFromConsole(DefaultInputs.EnterChoice, 0, 6);

            if (choice == 0)
                return;

            CityInfo? cityInfo = null;

            try
            {
                Task<CityInfo?> task;

                switch (choice)
                {
                    case 1:
                        task = WeatherDownloads.DownloadCityInfoByName("Vitebsk");
                        break;
                    case 2:
                        task = WeatherDownloads.DownloadCityInfoByName("Moscow");
                        break;
                    case 3:
                        task = WeatherDownloads.DownloadCityInfoByName("London");
                        break;
                    case 4:
                        task = WeatherDownloads.DownloadCityInfoByName("Tokio");
                        break;
                    case 5:
                        task = WeatherDownloads.DownloadCityInfoByName("New York");
                        break;
                    default:
                        task = WeatherDownloads.DownloadCityInfoByName(
                            DefaultInputs.GetCorrectStringFromConsole(DefaultInputs.EnterCity));
                        break;
                }

                cityInfo = task.GetAwaiter().GetResult();
            }
            catch (HttpRequestException e)
            {
                ShowMessageMenu($"Download City request exception, status code - {e.StatusCode}, try again next time.");
            }

            if (cityInfo == null)
            {
                ShowMessageMenu("Something went wrong while Downloading City Info. CityInfo is null.");
                return;
            }

            if (cityInfo.Code != 200)
            {
                ShowMessageMenu($"Something went wrong while Downloading City Info - status code {cityInfo.Code}");
                return;
            }

            if (forToday)
                HandleDownloadWeather(cityInfo);
            else
                HandleDownloadForecast(cityInfo);
        }

        private static void HandleDownloadWeather(CityInfo cityInfo)
        {
            AllWeatherInfo? allWeatherInfo = null;

            try
            {
                allWeatherInfo = WeatherDownloads.DownloadWeather(cityInfo).GetAwaiter().GetResult();
            }
            catch (HttpRequestException e)
            {
                ShowMessageMenu(
                    $"Download Weather request exception, status code - {e.StatusCode}, try again next time.");
            }

            if (allWeatherInfo == null)
            {
                ShowMessageMenu($"Something went wrong while Downloading Weather - weather info is null.");
                return;
            }

            if (allWeatherInfo.Code == 200)
                ShowWeatherMenu(allWeatherInfo, cityInfo);
            else
                ShowMessageMenu($"Something went wrong while Downloading Weather - status code {allWeatherInfo.Code}");
        }

        private static void HandleDownloadForecast(CityInfo cityInfo)
        {
            ForecastInfo? forecastInfo = null;

            try
            {
                forecastInfo = WeatherDownloads.DownloadForeCast(cityInfo).GetAwaiter().GetResult();
            }
            catch (HttpRequestException e)
            {
                ShowMessageMenu(
                    $"Download Forecast request exception, status code - {e.StatusCode}, try again next time.");
            }

            if (forecastInfo == null)
            {
                ShowMessageMenu("Something went wrong while Downloading Forecast - forecast info is null.");
                return;
            }

            if (forecastInfo.Code == 200)
                ShowForecastMenu(forecastInfo, cityInfo);
            else
                ShowMessageMenu($"Something went wrong while Downloading Forecast - status code {forecastInfo.Code}");
        }

        private static void ShowWeatherMenu(AllWeatherInfo weatherInfo, CityInfo cityInfo)
        {
            var s = new StringBuilder();

            s.AppendLine($"Today's weather forecast for {cityInfo.Name}:");
            s.AppendLine(weatherInfo.ToString());

            ShowMessageMenu(s.ToString());
        }

        private static void ShowForecastMenu(ForecastInfo forecastInfo, CityInfo cityInfo)
        {
            var s = new StringBuilder();

            s.AppendLine($"5 day Weather forecast for {cityInfo.Name}:");
            s.AppendLine(forecastInfo.ToString());

            ShowMessageMenu(s.ToString());
        }

        private static void ShowMessageMenu(string message)
        {
            Console.Clear();
            Console.WriteLine(message);
            Console.WriteLine("\n\r0 - Back.");

            DefaultInputs.GetCorrectNumberFromConsole(DefaultInputs.EnterChoice, 0, 0);

            ShowMainMenu();
        }
    }
}