namespace CWDApi.Entities
{
    public class Habit
    {
        public required int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Frequency { get; set; } = "daily";
        public int Progress { get; set; }
    }
}
