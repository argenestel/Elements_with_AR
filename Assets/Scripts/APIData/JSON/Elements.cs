namespace Chemistry
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Elements
    {
        [JsonProperty("atomicMass")]
        public string AtomicMass { get; set; }

        [JsonProperty("atomicNumber")]
        public long AtomicNumber { get; set; }

        [JsonProperty("atomicRadius")]
        public long AtomicRadius { get; set; }

        [JsonProperty("boilingPoint")]
        public long BoilingPoint { get; set; }

        [JsonProperty("bondingType")]
        public string BondingType { get; set; }

        [JsonProperty("cpkHexColor")]
        public string CpkHexColor { get; set; }

        [JsonProperty("density")]
        public double Density { get; set; }

        [JsonProperty("electronAffinity")]
        public long ElectronAffinity { get; set; }

        [JsonProperty("electronegativity")]
        public long Electronegativity { get; set; }

        [JsonProperty("electronicConfiguration")]
        public string ElectronicConfiguration { get; set; }

        [JsonProperty("groupBlock")]
        public string GroupBlock { get; set; }

        [JsonProperty("ionRadius")]
        public string IonRadius { get; set; }

        [JsonProperty("ionizationEnergy")]
        public long IonizationEnergy { get; set; }

        [JsonProperty("meltingPoint")]
        public long MeltingPoint { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("oxidationStates")]
        public long OxidationStates { get; set; }

        [JsonProperty("standardState")]
        public string StandardState { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("vanDerWaalsRadius")]
        public string VanDerWaalsRadius { get; set; }

        [JsonProperty("yearDiscovered")]
        public string YearDiscovered { get; set; }
    }
}
