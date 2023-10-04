using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    int corrAns = 0;
    int QuestionSeen = 0;

    public int GetCorrAns()
    {
        return corrAns;
    }
    public void SetCorrAns()
    {
        corrAns++;
        Debug.Log(corrAns);
    }

    public int GetQuestionSeen()
    {
        return QuestionSeen;
    }
    public void SetQuestionSeen()
    {
        QuestionSeen++;
        Debug.Log(QuestionSeen);
    }
    public int CalculateScore()
    {
        return Mathf.RoundToInt(corrAns / (float)QuestionSeen * 100);
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
