using System.Text.Json.Serialization;
namespace MicroserviceСompositeSC.Models;
public class RatingOfTeacher
{
    [JsonPropertyName("name")]
    public string Name { get; set; }


    [JsonPropertyName("subject")]
    public double Subject { get; set; }


    [JsonPropertyName("worktime")]
    public string Worktime { get; set; }
}