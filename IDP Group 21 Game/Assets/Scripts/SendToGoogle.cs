using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class SendToGoogle : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TMP_InputField feedback1, feedback2, feedback3, feedback4, feedback5, feedback6, feedback7, feedback8, feedback9, feedback10, feedback11, feedback12, feedback13;
    private string URL = 
"https://docs.google.com/forms/u/1/d/e/1FAIpQLScR5p9LFN912iWtuoAMTJTF5kPC6TUZi6G_JFSJ2csOh-LvRA/formResponse";

    public void Send()
    {
        StartCoroutine (Post(feedback1.text, feedback2.text, feedback3.text, feedback4.text, feedback5.text, feedback6.text, feedback7.text, feedback8.text, feedback9.text, feedback10.text, feedback11.text, feedback12.text, feedback13.text));

    }

    IEnumerator Post(string HeartRate, string LikeDislike, string AdditionToGame, string Rating, string Difficulty, string Puzzle1Time, string Puzzle2Time, string Puzzle3Time, string GameCompletionTime, string Username, string Puzzle1Hints, string Puzzle2Hints, string Puzzle3Hints)
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.1391831018", HeartRate);
        form.AddField("entry.280210706", LikeDislike);
        form.AddField("entry.1859565268", AdditionToGame);
        form.AddField("entry.497582451", Rating);
        form.AddField("entry.164929781", Difficulty);
        form.AddField("entry.2111165258", Puzzle1Time);
        form.AddField("entry.671434471", Puzzle2Time);
        form.AddField("entry.1790603514", Puzzle3Time);
        form.AddField("entry.1498663225", GameCompletionTime);
        form.AddField("entry.981346326", Username);
        form.AddField("entry.1529805302", Puzzle1Hints);
        form.AddField("entry.33904186", Puzzle2Hints);
        form.AddField("entry.1259053170", Puzzle3Hints);
        UnityWebRequest www = UnityWebRequest.Post(URL, form);
       
        yield return www.SendWebRequest();

    }
}
