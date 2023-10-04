using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    EndScreen end;
    Quiz quiz;
    //Test scoreKeeper;
    void Start()
    {
        end = FindObjectOfType<EndScreen>();
        quiz = FindObjectOfType<Quiz>();
        //scoreKeeper = FindObjectOfType<Test>();

        end.gameObject.SetActive(false);
        quiz.gameObject.SetActive(true);
    }


    void Update()
    {
        if (quiz.isComplete())
        {
            end.gameObject.SetActive(true);
            quiz.gameObject.SetActive(false);
            //end.SetTxt();
        }
    }
    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
