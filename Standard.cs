namespace AppService
{
    public partial class Standard
    {
        public int StandardId { get; set; }
        public string? StandardName { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
    }

}
