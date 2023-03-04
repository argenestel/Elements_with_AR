namespace Chemistry
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class ElementsJson
    {
        [JsonProperty("elements")]
        public Element[] ElementsElements { get; set; }
    }

    public partial class Element
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("appearance")]
        public string Appearance { get; set; }

        [JsonProperty("atomic_mass")]
        public double AtomicMass { get; set; }

        [JsonProperty("boil")]
        public double? Boil { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("density")]
        public double? Density { get; set; }

        [JsonProperty("discovered_by")]
        public string DiscoveredBy { get; set; }

        [JsonProperty("melt")]
        public double? Melt { get; set; }

        [JsonProperty("molar_heat")]
        public double? MolarHeat { get; set; }

        [JsonProperty("named_by")]
        public string NamedBy { get; set; }

        [JsonProperty("number")]
        public long Number { get; set; }

        [JsonProperty("period")]
        public long Period { get; set; }

        [JsonProperty("group")]
        public long Group { get; set; }

        [JsonProperty("phase")]
        public Phase Phase { get; set; }

        [JsonProperty("source")]
        public Uri Source { get; set; }

        [JsonProperty("bohr_model_image")]
        public Uri BohrModelImage { get; set; }

        [JsonProperty("bohr_model_3d")]
        public Uri BohrModel3D { get; set; }

        [JsonProperty("spectral_img")]
        public Uri SpectralImg { get; set; }

        [JsonProperty("summary")]
        public string Summary { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("xpos")]
        public long Xpos { get; set; }

        [JsonProperty("ypos")]
        public long Ypos { get; set; }

        [JsonProperty("wxpos")]
        public long Wxpos { get; set; }

        [JsonProperty("wypos")]
        public long Wypos { get; set; }

        [JsonProperty("shells")]
        public long[] Shells { get; set; }

        [JsonProperty("electron_configuration")]
        public string ElectronConfiguration { get; set; }

        [JsonProperty("electron_configuration_semantic")]
        public string ElectronConfigurationSemantic { get; set; }

        [JsonProperty("electron_affinity")]
        public double? ElectronAffinity { get; set; }

        [JsonProperty("electronegativity_pauling")]
        public double? ElectronegativityPauling { get; set; }

        [JsonProperty("ionization_energies")]
        public double[] IonizationEnergies { get; set; }

        [JsonProperty("cpk-hex")]
        public string CpkHex { get; set; }

        [JsonProperty("image")]
        public Image Image { get; set; }

        [JsonProperty("block")]
        public Block Block { get; set; }
    }

    public partial class Image
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("attribution")]
        public string Attribution { get; set; }
    }

    public enum Block { D, F, P, S };

    public enum Phase { Gas, Liquid, Solid };

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                BlockConverter.Singleton,
                PhaseConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class BlockConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Block) || t == typeof(Block?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "d":
                    return Block.D;
                case "f":
                    return Block.F;
                case "p":
                    return Block.P;
                case "s":
                    return Block.S;
            }
            throw new Exception("Cannot unmarshal type Block");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Block)untypedValue;
            switch (value)
            {
                case Block.D:
                    serializer.Serialize(writer, "d");
                    return;
                case Block.F:
                    serializer.Serialize(writer, "f");
                    return;
                case Block.P:
                    serializer.Serialize(writer, "p");
                    return;
                case Block.S:
                    serializer.Serialize(writer, "s");
                    return;
            }
            throw new Exception("Cannot marshal type Block");
        }

        public static readonly BlockConverter Singleton = new BlockConverter();
    }

    internal class PhaseConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Phase) || t == typeof(Phase?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Gas":
                    return Phase.Gas;
                case "Liquid":
                    return Phase.Liquid;
                case "Solid":
                    return Phase.Solid;
            }
            throw new Exception("Cannot unmarshal type Phase");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Phase)untypedValue;
            switch (value)
            {
                case Phase.Gas:
                    serializer.Serialize(writer, "Gas");
                    return;
                case Phase.Liquid:
                    serializer.Serialize(writer, "Liquid");
                    return;
                case Phase.Solid:
                    serializer.Serialize(writer, "Solid");
                    return;
            }
            throw new Exception("Cannot marshal type Phase");
        }

        public static readonly PhaseConverter Singleton = new PhaseConverter();
    }
}
