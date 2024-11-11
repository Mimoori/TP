using System.Text.Json.Serialization;
namespace MicroserviceСompositeSC.Models;
public class RatingOfStudent
{
    [JsonPropertyName("name")]
    public string Name { get; set; }


    [JsonPropertyName("groupname")]
    public string GroupName { get; set; }


    [JsonPropertyName("rating")]
    public double Rating { get; set; }
}