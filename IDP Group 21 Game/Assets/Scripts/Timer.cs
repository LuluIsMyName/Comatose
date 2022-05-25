using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    public static bool timerActive = true;
    public static float currentTime = 30;
    public float startMinutes;
    public TextMeshProUGUI timerText;

    // Start is called before the first frame update
    void Awake()
    {
        // DontDestroyOnLoad(this.gameObject);
        currentTime = startMinutes * 60;
    }

    // Update is called once per frame
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
        timerText.text = time.Minutes.ToString() + ":" + time.Seconds.ToString();
    }
}
