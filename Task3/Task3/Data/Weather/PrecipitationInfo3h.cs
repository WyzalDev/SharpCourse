// Copyright (c) 2012-2021 FuryLion Group. All Rights Reserved.

using Newtonsoft.Json;

namespace Task3.Data.Weather
{
    public class PrecipitationInfo3h
    {
        [JsonProperty("3h")] public double ThreeHours { get; set; }
    }
}