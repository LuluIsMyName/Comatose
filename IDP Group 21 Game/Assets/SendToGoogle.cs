using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class SendToGoogle : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TMP_InputField feedback1, feedback2, feedback3, feedback4, feedback5;
    private string URL = 
"https://docs.google.com/forms/u/1/d/e/1FAIpQLScR5p9LFN912iWtuoAMTJTF5kPC6TUZi6G_JFSJ2csOh-LvRA/formResponse";

    public void Send()
    {
        StartCoroutine (Post(feedback1.text, feedback2.text, feedback3.text, feedback4.text, feedback5.text));

    }

    IEnumerator Post(string HeartRate, string LikeDislike, string AdditionToGame, string Rating, string Difficulty)
    {
        WWWForm form = new WWWForm();
        form.AddField("entry.1391831018", HeartRate);
        form.AddField("entry.280210706", LikeDislike);
        form.AddField("entry.1859565268", AdditionToGame);
        form.AddField("entry.497582451", Rating);
        form.AddField("entry.164929781", Difficulty);
        UnityWebRequest www = UnityWebRequest.Post(URL, form);
       
        yield return www.SendWebRequest();

    }
}
