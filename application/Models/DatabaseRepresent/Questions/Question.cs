using application.Models.Answers;

namespace application.Models;

public class Question
{
    public int Id { get; set; }
    /*
     
     There can only be 3 values, 0, 1 and 2:
     0 - Question with free text answer
     1|2 - Question with choice answer (1 - multi or 2 - single)
     
     */
    public int Type { get; set; }
    public string Text { get; set; } = string.Empty;
    public List<QuestionVisibility> Visibilities { get; set; } = new();
    public List<PossibleAnswer> PossibleAnswers { get; set; } = new();
    public List<Answer>? Answers { get; set; } = new();
}