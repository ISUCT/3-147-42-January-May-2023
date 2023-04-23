using System.Text.Json;
using System.Text.Json.Serialization;
using application.Models;

namespace application.Additionals;

public class SurveySerializer : JsonConverter<SurveyModel>
{
    public override SurveyModel? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var surveyId = string.Empty;
        var surveyTitle = string.Empty;
        var questions = new List<QuestionModel>();
        
        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.PropertyName)
            {
                var propertyName = reader.GetString();
                reader.Read();
                switch (propertyName?.ToLower())
                {
                    case "id":
                        surveyId = reader.GetString();
                        break;
                    
                    case "title":
                        surveyTitle = reader.GetString();
                        break;
                    
                    case "questions":
                        
                        while (reader.TokenType != JsonTokenType.EndArray && reader.Read())
                        {
                            var questionId = string.Empty;
                            var questionText = string.Empty;
                            var questionVisibility = new List<string>();
                            var questionType = -1;
                            var possibleAnswers = new List<string>();
                            while (reader.TokenType != JsonTokenType.EndObject && reader.Read())
                            {
                                if (reader.TokenType == JsonTokenType.PropertyName)
                                {
                                    var questionPropertyName = reader.GetString();
                                    reader.Read();
                                    switch (questionPropertyName?.ToLower())
                                    {
                                        case "q_id":
                                            questionId = reader.GetString();
                                            break;
                                        case "text":
                                            questionText = reader.GetString();
                                            break;
                                        case "visibility":
                                            while (reader.TokenType != JsonTokenType.EndArray && reader.Read())
                                            {
                                                if (reader.TokenType == JsonTokenType.PropertyName)
                                                {
                                                    var visibilityPropertyName = reader.GetString();
                                                    reader.Read();
                                                    switch (visibilityPropertyName?.ToLower())
                                                    {
                                                        case "possibleanswertext":
                                                            questionVisibility.Add(reader.GetString());
                                                            break;
                                                    }
                                                }
                                            }
                                            break;
                                        case "type":
                                            questionType = reader.GetInt32();
                                            break;
                                        case "possibleanswers":
                                            while (reader.TokenType != JsonTokenType.EndArray && reader.Read())
                                            {
                                                if (reader.TokenType == JsonTokenType.PropertyName)
                                                {
                                                    var possibleAnswerPropertyName = reader.GetString();
                                                    reader.Read();
                                                    switch (possibleAnswerPropertyName?.ToLower())
                                                    {
                                                        case "answertext":
                                                            var possibleAnswer = reader.GetString();
                                                            possibleAnswers.Add(possibleAnswer);
                                                            break;
                                                    }
                                                }
                                            }
                                            break;
                                    }
                                }
                            }

                            var question = new QuestionModel(questionId, questionText, questionType, questionVisibility,
                                possibleAnswers);
                            questions.Add(question);
                            questionId = string.Empty;
                            questionText = string.Empty;
                            questionType = -1;
                            questionVisibility = new();
                            possibleAnswers = new();

                        }
                        break;
                }
            }
        }

        return new SurveyModel(surveyId, surveyTitle, questions);
    }

    public override void Write(Utf8JsonWriter writer, SurveyModel value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        
        writer.WriteString("Id", value.Id);
        writer.WriteString("Title", value.Title);
        writer.WriteStartArray("Questions");
        foreach (var question in value.Questions)
        {
            writer.WriteStartObject();
            
            writer.WriteString("Id", question.Id);
            writer.WriteString("Text", question.Text);
            writer.WriteNumber("Type", question.Type);
            
            writer.WriteStartArray("Visibility");
            foreach (var position in question.Visibility)
            {
                writer.WriteStartObject();
                
                writer.WriteString("Position", position);
                
                writer.WriteEndObject();
            }
            writer.WriteEndArray();
            if (question.Type == 1)
            {
                writer.WriteStartArray("PossibleAnswers");
                foreach (var answer in question.PossibleAnswers)
                {
                    writer.WriteStartObject();
                    
                    writer.WriteString("PossibleAnswer", answer);
                    
                    writer.WriteEndObject();
                }

                writer.WriteEndArray();
            }

            writer.WriteEndObject();
        }
        writer.WriteEndArray();
        
        writer.WriteEndObject();
    }
}