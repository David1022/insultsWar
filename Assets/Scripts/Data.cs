using System.Collections.Generic;

[System.Serializable]
public class Data
{
    public List<Question> data;
}

[System.Serializable]
public class Question
{
    public string question;
    public string answer;
}