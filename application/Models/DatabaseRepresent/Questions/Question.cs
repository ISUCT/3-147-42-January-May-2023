namespace application.Models;

public class Question
{
    public int Id { get; set; }
    /*
     
     There can only be 2 values, 0 and 1:
     0 - Question with free text answer
     1 - Question with choice answer (multi or single, anyway)
     
     */
    public int Type { get; set; }
    public string Text { get; set; } = string.Empty;
}