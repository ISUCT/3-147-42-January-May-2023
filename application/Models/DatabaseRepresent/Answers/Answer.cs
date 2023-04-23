using System.ComponentModel.DataAnnotations;

namespace application.Models.Answers;

public class Answer
{
    public int Id { get; set; }
    public int QuestionId { get; set; }
    public string Text { get; set; } = string.Empty;
}