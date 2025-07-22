// Copyright (c) 2012-2021 FuryLion Group. All Rights Reserved.

using Newtonsoft.Json;

namespace Task3.Data.Weather
{
    public class PrecipitationInfo1h
    {
        [JsonProperty("1h")] public double OneHour { get; set; }
    }
}