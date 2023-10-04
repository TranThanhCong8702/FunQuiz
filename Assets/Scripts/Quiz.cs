//using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [SerializeField] GameObject[] answerButton;
    [SerializeField] TextMeshProUGUI textMeshPro;
    [SerializeField] QuestionSO question;
    [SerializeField] List<QuestionSO> QuestionsList = new List<QuestionSO>();
    int correctAnsIndex;
    [SerializeField] Sprite Normal;
    [SerializeField] Sprite Correct;

    bool hasAnsEarly;
    [SerializeField] Image TimerImage;
    Timer timer;

    [SerializeField] TextMeshProUGUI Score;
    Test test;

    [SerializeField] Slider ProgressBar;
    bool iscompleted;
    void Start()
    {
        test = FindObjectOfType<Test>();
        timer = FindObjectOfType<Timer>();
        //AddQuestion();
    }
    public void OnAnsClick(int index)
    {
        hasAnsEarly = true;
        DisplayAns(index);
        GetAnsState(false);
        timer.CancelTimer();
        Score.text = "Score: "+ test.CalculateScore() +"%";
    }
    public bool isComplete()
    {
        return iscompleted;
    }
    private void DisplayAns(int index)
    {
        Image image;
        if (index == question.getAnsIndex())
        {
            textMeshPro.text = "Correct";
            image = answerButton[index].GetComponent<Image>();
            image.sprite = Correct;
            test.SetCorrAns();
        }
        else
        {
            textMeshPro.text = "Incorrect, The Answer is: \n" + question.GetAnswer(correctAnsIndex);
            image = answerButton[correctAnsIndex].GetComponent<Image>();
            image.sprite = Correct;
        }
    }

    private void GetAns()
    {
        for (int i = 0; i < answerButton.Length; i++)
        {
            TextMeshProUGUI text = answerButton[i].GetComponentInChildren<TextMeshProUGUI>();
            text.text = question.GetAnswer(i);
        }
    }

    private void AddQuestion()
    {
        if (QuestionsList.Count > 0)
        {
            SetDefaultButton();
            GetAnsState(true);
            GetRandomQ();
            ProgressBar.value++;
            //ProgressBar.value = test.GetQuestionSeen();
            test.SetQuestionSeen();
        }
        else
        {
            iscompleted = true;
        }
    }

    private void GetRandomQ()
    {
        int index = Random.Range(0, QuestionsList.Count);
        question = QuestionsList[index];
        correctAnsIndex = question.getAnsIndex();
        textMeshPro.text = question.GetQuestion();
        GetAns();
        if (QuestionsList.Contains(question))
        {
            QuestionsList.Remove(question);
        }
    }

    void GetAnsState(bool state)
    {
        for(int i=0;i<answerButton.Length; i++)
        {
            Button ansbutton = answerButton[i].GetComponent<Button>();
            ansbutton.interactable = state;
        }
    }
    void SetDefaultButton()
    {
        for (int i = 0; i < answerButton.Length; i++)
        {
            Image image = answerButton[i].GetComponent<Image>();
            image.sprite = Normal;
        }
    }
    void Update()
    {
        TimerImage.fillAmount = timer.fillFraction;
        if (timer.loadNextQ)
        {
            hasAnsEarly = false;
            AddQuestion();
            timer.loadNextQ = false;
        }
        else if(!hasAnsEarly && !timer.GetisAnswering())
        {
            DisplayAns(-1);
            GetAnsState(false);
            Score.text = "Score: " + test.CalculateScore() + "%";
        }
    }
}
