namespace GraphQl.Models
{
    public class Activity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int? AssignedToId { get; set; }
        public User AssignedTo { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
