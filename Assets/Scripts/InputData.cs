using System.Collections.Generic;

[System.Serializable]
public class InputData
{
    public List<Question> data;
}

[System.Serializable]
public class Question
{
    public string question;
    public string answer;
}