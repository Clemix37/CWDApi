namespace CWDApi.DTOs
{
    public class HabitCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public string Frequency { get; set; } = "daily";
    }

    public class HabitReadDto
    {
        public required int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Frequency { get; set; } = "daily";
        public int Progress { get; set; }
    }

    public class HabitUpdateDto
    {
        public required int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Frequency { get; set; } = "daily";
        public int Progress { get; set; }
    }
}
