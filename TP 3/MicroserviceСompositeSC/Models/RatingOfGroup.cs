using System.Text.Json.Serialization;
namespace MicroserviceСompositeSC.Models;
public class RatingOfGroup
{
    [JsonPropertyName("groupName")]
    public string GroupName { get; set; }

    [JsonPropertyName("rating")]
    public double Rating { get; set; }
}