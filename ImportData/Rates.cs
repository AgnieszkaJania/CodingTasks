using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ProcessData
{
    public class Rate
    {
        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("mid")]
        public decimal Mid { get; set; }

        public override string ToString()
        {
            return $"Currency: {Currency}, Code: {Code}, Mid: {Mid} ==========";
        }
    }
    public class ExchangeRate
    {
        [JsonProperty("table")]
        public string Table { get; set; }

        [JsonProperty("no")]
        public string No { get; set; }

        [JsonProperty("effectiveDate")]
        public DateTime EffectiveDate { get; set; }

        [JsonProperty("rates")]
        public List<Rate> Rates { get; set; }
    }
}
