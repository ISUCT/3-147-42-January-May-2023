# Author of the solution

Boyarkin Artem 3/42


# Installation

## Open terminal in any folder u want to use and then
1. git clone https://github.com/ISUCT/3-147-42-January-May-2023/tree/Survey_Backend
2. cd 3-147-42-January-May-2023
3. docker-compose up

after you can find API on http://localhost/Api/{your_command}

## Requirements
1. `Docker`/`docker-compose` installed
2. `Git` installed

## PS
If u want to change ip or port, u should edit launchSettings.json file (u can find it at `~/3-147-42-January-May-2023/application/Properties/`)


# How u can use this backend(commands)

## Common ways
- Add survey - `.../AddSurvey` (with appropriate json) -> OK|Code 204(if json is not appropriate)
- Get survey/s - `.../GetSurvey` (if u want to get only one survey, just add "id" in query: `.../GetSurvey?id=0`) -> OK|NotFound(404)
- Update survey - `.../UpdateSurvey` (with appropriate json) -> OK|Code 204(if json is not appropriate)
- Delete survey - `.../DeleteSurvey?id=0` (0 is example) -> OK|NotFound(404)

## Uncommon ways
Any Question in questions array in `JSON`, that u received, has field Answers.
It can be `NULL` or array with appropriate answers and then u can send only answers
array with SurveyUpdate API method to link answers with Survey in database.
In the same way you can read only answers array from received `JSON`.

## `JSON` example
Also u can find `JSON` example at `~/3-147-42-January-May-2023/application/Examples/SurveyExample.json`
```json
{
  "Id": 1,
  "Title" : "SurveyTitle",
  "Questions": [
    {
      "Id": 1,
      "Text": "QuestionText",
      "Visibility": [
        {
          "Id": 1,
          "Text": "RoleInProject"},
        {
          "Id": 2,
          "Text": "RoleInProject"},
        {
          "Id": 3,
          "Text": "RoleInProject"},
        {
          "Id": 4,
          "Text": "RoleInProject"},
        {
          "Id": 5,
          "Text": "RoleInProject"}
      ],
      "Type": 0,
      "Answers": null
    },
    {
      "Id": 2,
      "Text": "QuestionText",
      "Visibility": [
        {
          "Id": 6,
          "Position": "RoleInProject"},
        {
          "Id": 7,
          "Position": "RoleInProject"}
      ],
      "Type": 1,
      "PossibleAnswers": [
        {
          "Id": 1,
          "Text": "PossibleAnswerText"},
        {
          "Id": 1,
          "Text": "PossibleAnswerText"},
        {
          "Id": 1,
          "Text": "PossibleAnswerText"},
        {
          "Id": 1,
          "Text": "PossibleAnswerText"},
        {
          "Id": 1,
          "Text": "PossibleAnswerText"}
      ],
      "Answers": [
        {
          "Id": 1,
          "Text": "AnswerText"
        },
        {
          "Id": 2,
          "Text": "AnswerText"
        },
        {
          "Id": 3,
          "Text": "AnswerText"
        }
      ]
    }
  ]
}
                                                
 ```



