namespace application.Models;

public class SurveyModel
{
    public string Id { get; }
    public string Title { get; }
    public List<QuestionModel> Questions { get; }

    public SurveyModel(string id, string title, List<QuestionModel> questions)
    {
        Id = id;
        Title = title;
        Questions = questions;
    }
}