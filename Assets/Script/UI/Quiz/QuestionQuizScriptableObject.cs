using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Quiz Data", menuName = "ScriptableObjects/QuizData", order = 0)]
public class QuestionQuizScriptableObject : ScriptableObject
{ 
    public Texture2D QuestionImage;
    public string QuestionText;
    public List<Answer> AnswerData;
}

[System.Serializable]
public struct Answer
{
    public string AnswerText;
    public Texture AnswerImage;
    public bool isCorrect;
}
