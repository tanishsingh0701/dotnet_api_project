using System.Text.Json.Serialization;

namespace dotnet_api_project
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RpgClass
    {
        knight,
        Mage,
        Cleric

    }
}