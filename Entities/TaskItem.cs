namespace CWDApi.Entities
{
    public class TaskItem
    {
        public int Id { get; set; } = 0;
        public required string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
