// Copyright (c) 2012-2021 FuryLion Group. All Rights Reserved.

using System;
using Newtonsoft.Json;

namespace Task3.Data.Weather
{
    [Serializable]
    public class PrecipitationInfo1h
    {
        [JsonProperty("1h")] public double OneHour { get; set; }
    }
}