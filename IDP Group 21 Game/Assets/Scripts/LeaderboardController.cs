using UnityEngine.UI;
using LootLocker.Requests;
using UnityEngine;
using TMPro;

public class LeaderboardController : MonoBehaviour
{
    public TMP_InputField MemberID, PlayerScore;
    public int ID;
    int MaxScores = 4;
    public TextMeshProUGUI[] Entries;

    private void Start()
    {
        LootLockerSDKManager.StartSession("lol", (response) =>
        {
            if (response.success)
            {
                Debug.Log("Session started");
            }
            else
            {
                Debug.Log("Session failed to start");
            }
        });
    }
    public void ShowScores()
    {
        LootLockerSDKManager.GetScoreList(ID, MaxScores, (response) =>
        {
            if (response.success)
            {
                LootLockerLeaderboardMember[] scores = response.items;
                for(int i =0; i < scores.Length; i++)
                {
                    // Entries[i].text = (scores[i].rank +  ".   " + scores[i].score);
                    Entries[i].text = (scores[i].rank + "    " + scores[i].member_id + ".   " + scores[i].score);
                }

                if(scores.Length < MaxScores)
                {
                    for(int i = scores.Length; i < MaxScores; i++)
                    {
                        Entries[i].text = (i + 1).ToString() + ".   none";
                    }
                }
                
            }
            else
            {
                Debug.Log("Session failed to start");
            }
        });
    }
    public void SubmitScore()
    {
        LootLockerSDKManager.SubmitScore(MemberID.text, int.Parse(PlayerScore.text), ID, (response) =>
        {
            if (response.success)
            {
                Debug.Log("Score submitted");
            }
            else
            {
                Debug.Log("Score failed to submit");
            }
        });
    }

}
