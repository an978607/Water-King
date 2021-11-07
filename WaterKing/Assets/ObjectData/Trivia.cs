using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Trivia
{
    [SerializeField] private int id;
    public string question;
    public string answer1;
    public string answer2;
    public string answer3;
    public string answer4;
    [SerializeField] private int correctAnswer;
    [SerializeField] private int reward;
    [System.NonSerialized] public List<string> AnswerList;

    public Trivia()
    {
        AnswerList = new List<string>();
    }

    public Trivia(int id, string question, List<string> AnswerList, int correctAnswer, int reward)
    {
        this.id = id;
        this.question = question;
        answer1 = AnswerList[0];
        answer2 = AnswerList[1];
        answer3 = AnswerList[2];
        answer4 = AnswerList[3];
        this.correctAnswer = correctAnswer;
        this.reward = reward;
    }

    public string GetCorrectAnswer()
    {
        return AnswerList[correctAnswer-1];
    }

    public int GetReward()
    {
        return reward;
    }
}
