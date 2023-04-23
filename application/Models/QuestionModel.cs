namespace application.Models;

public class QuestionModel
{
    public string Id { get; }
    public string Text { get; }
    public int Type { get; }
    public List<string> Visibility { get; }
    public List<string> PossibleAnswers { get; }

    public QuestionModel(string id, string text, int type, List<string> visibility, List<string> possibleAnswers)
    {
        Id = id;
        Text = text;
        Type = type;
        Visibility = visibility;
        PossibleAnswers = possibleAnswers;
    }
}