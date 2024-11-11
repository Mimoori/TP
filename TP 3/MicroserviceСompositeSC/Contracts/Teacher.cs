using System.Text.Json.Serialization;

namespace MicroserviceTeacher.Models
{
    public class Teacher
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("subject")]
        public string Subject { get; set; }

        [JsonPropertyName("worktime")]
        public int Worktime { get; set; }

    }
}

