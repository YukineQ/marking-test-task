using System.Text.Json.Serialization;

namespace marking_test_task.Models.Responce
{
    public class CurrentTask
    {
        [JsonPropertyName("mission")]
        public MissionResponce MissionResponce { get; set; }
    }

    public class MissionResponce
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("dateAt")]
        public string DateAt { get; set; }

        [JsonPropertyName("codeTypeId")]
        public int CodeTypeId { get; set; }

        [JsonPropertyName("lot")]
        public Lot Lot { get; set; }
    }

    public class Lot
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("dateAt")]
        public string DateAt { get; set; }

        [JsonPropertyName("package")]
        public Package Package { get; set; }

        [JsonPropertyName("product")]
        public Product Product { get; set; }
    }

    public class Package
    {
        [JsonPropertyName("volume")]
        public string Volume { get; set; }

        [JsonPropertyName("boxFormat")]
        public int BoxFormat { get; set; }

        [JsonPropertyName("palletFormat")]
        public int PalletFormat { get; set; }
    }

    public class Product
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("fullName")]
        public string FullName { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("gtin")]
        public string Gtin { get; set; }

        [JsonPropertyName("standart")]
        public string Standard { get; set; }

        [JsonPropertyName("shelfLife")]
        public string ShelfLife { get; set; }

        [JsonPropertyName("barcodeShelLife")]
        public int BarcodeShelfLife { get; set; }

        [JsonPropertyName("barcodeShelfLifeUnit")]
        public string BarcodeShelfLifeUnit { get; set; }

        [JsonPropertyName("moreInfo")]
        public string MoreInfo { get; set; }
    }
}
