// Copyright (c) 2012-2021 FuryLion Group. All Rights Reserved.

using System;
using Newtonsoft.Json;

namespace Task3.Data.Weather
{
    [Serializable]
    public class WeatherInfo
    {
        [JsonProperty("main")] public string Main { get; set; }

        [JsonProperty("description")] public string Description { get; set; }
    }
}