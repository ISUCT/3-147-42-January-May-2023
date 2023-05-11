namespace application.Models;

public class Survey
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public List<Question> Questions { get; set; } = new();
}