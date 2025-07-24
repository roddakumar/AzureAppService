using System.Text.Json.Serialization;

namespace AppService
{
    public partial class Teacher
    {
        public int TeacherId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int StandardId { get; set; }
        [JsonIgnore]
        public virtual Standard Standard { get; set; } = null!;
    }

    public class TeacherCreateDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int StandardId { get; set; }
    }

    //
}