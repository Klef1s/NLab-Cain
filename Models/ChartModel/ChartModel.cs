using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace NLab_Cain.Models.ChartModel
{
    public class UrlChart
    {
        public static string url { get; set; }
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
        public ReleaseDate ReleaseDate { get; set; }
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

    public partial struct ReleaseDate
    {
        public DateTimeOffset? DateTime;
        public long? Integer;

        public static implicit operator ReleaseDate(DateTimeOffset DateTime) => new ReleaseDate { DateTime = DateTime };
        public static implicit operator ReleaseDate(long Integer) => new ReleaseDate { Integer = Integer };
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
                ReleaseDateConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class ReleaseDateConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(ReleaseDate) || t == typeof(ReleaseDate?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    DateTimeOffset dt;
                    if (DateTimeOffset.TryParse(stringValue, out dt))
                    {
                        return new ReleaseDate { DateTime = dt };
                    }
                    long l;
                    if (Int64.TryParse(stringValue, out l))
                    {
                        return new ReleaseDate { Integer = l };
                    }
                    break;
            }
            throw new Exception("Cannot unmarshal type ReleaseDate");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (ReleaseDate)untypedValue;
            if (value.DateTime != null)
            {
                serializer.Serialize(writer, value.DateTime.Value.ToString("o", System.Globalization.CultureInfo.InvariantCulture));
                return;
            }
            if (value.Integer != null)
            {
                serializer.Serialize(writer, value.Integer.Value.ToString());
                return;
            }
            throw new Exception("Cannot marshal type ReleaseDate");
        }

        public static readonly ReleaseDateConverter Singleton = new ReleaseDateConverter();
    }
}

