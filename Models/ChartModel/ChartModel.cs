using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace NLab_Cain.Models.ChartModel
{
    public class UrlChart
    {
        public static string url = "https://api.spotify.com/v1/playlists/37i9dQZEVXbMDoHDwVN2tF/tracks?";
    }

    public partial class ChartModel
    {
        [JsonProperty("items")]
        public Item[] Items { get; set; }
    }

    public partial class Item
    {
        [JsonProperty("added_by")]
        public AddedBy AddedBy { get; set; }

        [JsonProperty("track")]
        public Track Track { get; set; }
    }

    public partial class AddedBy
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public partial class Track
    {
        [JsonProperty("album")]
        public Album Album { get; set; }

        [JsonProperty("artists")]
        public Artist[] Artists { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class Album
    {
        [JsonProperty("images")]
        public Image[] Images { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("release_date")]
        public DateTimeOffset ReleaseDate { get; set; }
    }

    public partial class Image
    {
        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }
    }

    public partial class Artist
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class ChartModel
    {
        public static ChartModel FromJson(string json) => JsonConvert.DeserializeObject<ChartModel>(json, Models.ChartModel.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this ChartModel self) => JsonConvert.SerializeObject(self, Models.ChartModel.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeLocal }

            },
        };
    }
}


