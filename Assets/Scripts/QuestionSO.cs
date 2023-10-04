using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Question", fileName = "New Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2,6)]
    [SerializeField] string question = "Enter new question here!";
    [SerializeField] string[] answer = new string[4];
    [SerializeField] int correctAnsIndex;
    
    public string GetQuestion()
    {
        return question;
    }
    public int getAnsIndex()
    {
        return correctAnsIndex;
    }
    public string GetAnswer(int AnsIndex)
    {
        return answer[AnsIndex];
    }
}
