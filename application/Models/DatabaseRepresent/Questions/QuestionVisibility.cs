namespace application.Models;

public class QuestionVisibility
{
    public int Id { get; set; }
    public int QuestionId { get; set; }
    public string Position { get; set; } = string.Empty;
}