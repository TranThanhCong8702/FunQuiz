using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] float timetocomplete = 30f;
    [SerializeField] float timetoshowcorr = 10f;
    public bool loadNextQ;
    public float fillFraction;
    bool isAnswering;
    float TimerValue;

    public bool GetisAnswering()
    {
        return isAnswering;
    }
    private void Start()
    {

    }
    void Update()
    {
        UpdateTimer();
    }
    public void CancelTimer()
    {
        TimerValue = 0;
    }
    private void UpdateTimer()
    {
        TimerValue -= Time.deltaTime;
        if (isAnswering)
        {
            if(TimerValue > 0)
            {
                fillFraction = TimerValue / timetocomplete;
            }
            else
            {
                isAnswering = false;
                TimerValue = timetoshowcorr;
            }
        }
        else
        {
            if (TimerValue > 0)
            {
                fillFraction = TimerValue / timetoshowcorr;
            }
            else
            {
                isAnswering = true;
                TimerValue = timetocomplete;
                loadNextQ = true;
            }
        }
    }
}
