using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Fungus;

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
    public static float TimeLeft;


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
            Debug.Log(currentTime);
            if (currentTime <= 0)
            {
                timerActive = false;
                Debug.Log("Timer finished");
            }
        }
        TimeSpan time =TimeSpan.FromSeconds(currentTime);
        // timerText.text = time.Minutes.ToString() + ":" + time.Seconds.ToString();
        if (time.Seconds < 10)
        {
            timerText.text = time.Minutes.ToString() + ":0" + time.Seconds.ToString();
        }
        else 
        {
            timerText.text = time.Minutes.ToString() + ":" + time.Seconds.ToString();
        }
        if (Survey == true)
        {
            // Survey = flowchart.GetBooleanVariable("Survey");
            timerActive = false;
            TimeLeft = currentTime;
            // flowchart.SetIntegerVariable("TimeLeft", TimeLeft);
        }
    }
    void OutputTime()
    {
        time = timerText.text;
        Debug.Log(time);
    }
    void RoomChecker()
    {
        room = flowchart.GetStringVariable("CurrentRoom");
        Debug.Log(room);
    }
    public void Act1Hint1()
    {
        Hint1Used = flowchart.GetBooleanVariable("Hint1Used");

        if (Hint1Used == false)
        {
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
            currentTime = currentTime - 300;
            Answer2Used = true;
            flowchart.SetBooleanVariable("Answer2Used", Answer2Used);
        }
    }
    
}
