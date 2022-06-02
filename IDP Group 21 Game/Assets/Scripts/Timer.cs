using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Fungus;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public static bool timerActive = true;
    public static float currentTime = 30;
    public float startMinutes;
    public TextMeshProUGUI timerText;
    public static bool firstTime = true;   
    public static string time;
    public Flowchart flowchart;
    public static string room;
    public static bool Hint1Used;
    public static bool Hint2Used;
    public static bool Hint3Used;
    public static bool Answer1Used;
    public static bool Act2Hint1Used;
    public static bool Act2Hint2Used;
    public static bool Act2Hint3Used;
    public static bool Answer2Used;
    public static bool Act3Hint1Used;
    public static bool Act3Hint2Used;
    public static bool Act3Hint3Used;
    public static bool Answer3Used;
    public static bool Survey;
    public static string TimeLeft;

    public static bool Puzzle1Completed;
    public static string Puzzle1Time;
    public static bool Puzzle2Completed;
    public static string Puzzle2Time;
    public static bool Puzzle3Completed;
    public static string Puzzle3Time;
    public static int TempGameCompletionTime;
    public static string GameCompletionTime;
    public static int Puzzle1Hints = 0;
    public static string Puzzle2Hints = "0";
    public static string Puzzle3Hints = "0";
    public static bool GameOver;

    // Start is called before the first frame update
    void Awake()
    {
        if (firstTime == true)
        {
            currentTime = startMinutes * 60;
            firstTime = false;
            InvokeRepeating("OutputTime", 1f, 1f);

        }
    }

    // Update is called once per frame
    void Start()
    {

    }
    void Update()
    {   

        if (timerActive == true)
        {
            currentTime = currentTime - Time.deltaTime;
            if (currentTime <= 0)
            {
                timerActive = false;
                currentTime = 0;
                Debug.Log("Timer finished");
                SceneManager.LoadScene("Survey");
            }
        }
        TimeSpan time =TimeSpan.FromSeconds(currentTime);
        timerText.text = time.Minutes.ToString() + ":" + time.Seconds.ToString();
        if (time.Seconds < 10)
        {
            timerText.text = time.Minutes.ToString() + ":0" + time.Seconds.ToString();
        }
        else 
        {
            timerText.text = time.Minutes.ToString() + ":" + time.Seconds.ToString();
        }

        Survey = flowchart.GetBooleanVariable("Survey");
        
        if (Survey == true)
        {
            timerActive = false;
            TimeLeft = Mathf.RoundToInt(currentTime).ToString();
            flowchart.SetStringVariable("TimeLeft", TimeLeft);

            //these next two lines show how to make it so that it shows how many seconds it took instead of how many seconds left
            //we might either want this on the other 3 puzzle or we can just have it for game completion
            TempGameCompletionTime = 1800 - Mathf.RoundToInt(currentTime);
            GameCompletionTime = TempGameCompletionTime.ToString();
            flowchart.SetStringVariable("GameCompletionTime", GameCompletionTime);
        }
        Puzzle1Completed = flowchart.GetBooleanVariable("Puzzle1Completed");
        CheckPuzzle1Completion();
        
        Puzzle2Completed = flowchart.GetBooleanVariable("Puzzle2Completed");
        CheckPuzzle2Completion();

        Puzzle3Completed = flowchart.GetBooleanVariable("Puzzle3Completed");
        CheckPuzzle3Completion();

    }
    
    void CheckPuzzle1Completion()
    {
        if (Puzzle1Completed == true & Puzzle1Time == null)
        {   
            Puzzle1Time = Mathf.RoundToInt(currentTime).ToString();
            flowchart.SetStringVariable("Puzzle1Time", Puzzle1Time);
        }
    }
    void CheckPuzzle2Completion()
    {
        if (Puzzle2Completed == true & Puzzle2Time == null)
        {
            Puzzle2Time = Mathf.RoundToInt(currentTime).ToString();
            flowchart.SetStringVariable("Puzzle2Time", Puzzle2Time);
        }
    }
    void CheckPuzzle3Completion()
    {
        if (Puzzle3Completed == true & Puzzle3Time == null)
        {
            Puzzle3Time = Mathf.RoundToInt(currentTime).ToString();
            flowchart.SetStringVariable("Puzzle3Time", Puzzle3Time);
        }
    }

    void OutputTime()
    {
        time = timerText.text;
        Debug.Log(time);
        TimeLeft = Mathf.RoundToInt(currentTime).ToString();
        Debug.Log(TimeLeft);
    }
    public void Act1Hint1()
    {
        Hint1Used = flowchart.GetBooleanVariable("Hint1Used");

        if (Hint1Used == false)
        {   
            Puzzle1Hints += 1;
            flowchart.SetStringVariable("Puzzle1Hints", Puzzle1Hints.ToString());
            currentTime = currentTime - 60;
            Hint1Used = true;
            flowchart.SetBooleanVariable("Hint1Used", Hint1Used);
        }
    }
    public void Act1Hint2()
    {
        Hint2Used = flowchart.GetBooleanVariable("Hint2Used");

        if (Hint2Used == false)
        {
            Puzzle1Hints += 1;
            flowchart.SetStringVariable("Puzzle1Hints", Puzzle1Hints.ToString());
            currentTime = currentTime - 60;
            Hint2Used = true;
            flowchart.SetBooleanVariable("Hint2Used", Hint2Used);
        }
    }
    public void Act1Hint3()
    {
        Hint3Used = flowchart.GetBooleanVariable("Hint3Used");

        if (Hint3Used == false)
        {   
            Puzzle1Hints += 1;
            flowchart.SetStringVariable("Puzzle1Hints", Puzzle1Hints.ToString());
            currentTime = currentTime - 60;
            Hint3Used = true;
            flowchart.SetBooleanVariable("Hint3Used", Hint3Used);
        }
    }
    public void Act1Answer1()
    {
        Answer1Used = flowchart.GetBooleanVariable("Answer1Used");

        if (Answer1Used == false)
        {   
            Puzzle1Hints += 1;
            flowchart.SetStringVariable("Puzzle1Hints", Puzzle1Hints.ToString());
            currentTime = currentTime - 60;
            Answer1Used = true;
            flowchart.SetBooleanVariable("Answer1Used", Answer1Used);
        }
    }
    public void Act2Hint1()
    {
        Act2Hint1Used = flowchart.GetBooleanVariable("Act2Hint1Used");

        if (Act2Hint1Used == false)
        {   
            Puzzle2Hints = "1";
            flowchart.SetStringVariable("Puzzle2Hints", Puzzle2Hints);
            currentTime = currentTime - 60;
            Act2Hint1Used = true;
            flowchart.SetBooleanVariable("Act2Hint1Used", Act2Hint1Used);
        }
    }
    public void Act2Hint2()
    {
        Act2Hint2Used = flowchart.GetBooleanVariable("Act2Hint2Used");

        if (Act2Hint2Used == false)
        {   
            Puzzle2Hints = "2";
            flowchart.SetStringVariable("Puzzle2Hints", Puzzle2Hints);
            currentTime = currentTime - 120;
            Act2Hint2Used = true;
            flowchart.SetBooleanVariable("Act2Hint2Used", Act2Hint2Used);
        }
    }
    public void Act2Hint3()
    {
        Act2Hint3Used = flowchart.GetBooleanVariable("Act2Hint3Used");

        if (Act2Hint3Used == false)
        {   
            Puzzle2Hints = "3";
            flowchart.SetStringVariable("Puzzle2Hints", Puzzle2Hints);
            currentTime = currentTime - 120;
            Act2Hint3Used = true;
            flowchart.SetBooleanVariable("Act2Hint3Used", Act2Hint3Used);
        }
    }
    public void Answer2()
    {
        Answer2Used = flowchart.GetBooleanVariable("Answer2Used");

        if (Answer2Used == false)
        {
            Puzzle2Hints = "4";
            flowchart.SetStringVariable("Puzzle2Hints", Puzzle2Hints);
            currentTime = currentTime - 300;
            Answer2Used = true;
            flowchart.SetBooleanVariable("Answer2Used", Answer2Used);
        }   
    }
    public void Act3Hint1()
    {
        Act3Hint1Used = flowchart.GetBooleanVariable("Act3Hint1Used");

        if (Act3Hint1Used == false)
        {
            Puzzle3Hints = "1";
            flowchart.SetStringVariable("Puzzle3Hints", Puzzle3Hints);
            currentTime = currentTime - 60;
            Act3Hint1Used = true;
            flowchart.SetBooleanVariable("Act3Hint1Used", Act3Hint1Used);
        }
    }
    public void Act3Hint2()
    {
        Act3Hint2Used = flowchart.GetBooleanVariable("Act3Hint2Used");

        if (Act3Hint2Used == false)
        {   
            Puzzle3Hints = "2";
            flowchart.SetStringVariable("Puzzle3Hints", Puzzle3Hints);
            currentTime = currentTime - 60;
            Act3Hint2Used = true;
            flowchart.SetBooleanVariable("Act3Hint2Used", Act3Hint2Used);
        }
    }
    public void Act3Hint3()
    {
        Act3Hint3Used = flowchart.GetBooleanVariable("Act3Hint3Used");

        if (Act3Hint3Used == false)
        {
            Puzzle3Hints = "3";
            flowchart.SetStringVariable("Puzzle3Hints", Puzzle3Hints);
            currentTime = currentTime - 60;
            Act3Hint3Used = true;
            flowchart.SetBooleanVariable("Act3Hint3Used", Act3Hint3Used);
        }
    }
    public void Answer3()
    {
        Answer3Used = flowchart.GetBooleanVariable("Answer3Used");

        if (Answer3Used == false)
        {   
            Puzzle3Hints = "4";
            flowchart.SetStringVariable("Puzzle3Hints", Puzzle3Hints);
            currentTime = currentTime - 60;
            Answer3Used = true;
            flowchart.SetBooleanVariable("Answer3Used", Answer3Used);
        }
    }
}
