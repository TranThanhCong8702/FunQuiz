using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndScreen : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI textMeshProUGUI;
    Test scoreKeeper;
    private void Awake()
    {
        scoreKeeper = FindObjectOfType<Test>();
    }
    void Start()
    {
        SetTxt();

    }
    public void SetTxt()
    {
        textMeshProUGUI.text = "Congratulation!\n" + "Your score is: " + scoreKeeper.CalculateScore() + "%";
    }

}
