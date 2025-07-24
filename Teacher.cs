namespace AppService
{
    public partial class Teacher
    {
        public int TeacherId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int StandardId { get; set; }

        public virtual Standard Standard { get; set; } = null!;
    }

}