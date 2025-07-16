using UnityEngine;
using TMPro;        // using this namespace to access its classes 

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] TMP_Text scoreboardText; 

    int score = 0;      // initially the score is set to zero and when u hit the enemies the score increases 

    public void IncreaseScore(int amount)
    {
        score += amount;
        scoreboardText.text = score.ToString();     // we need a string here and as score is int we used ToString() to convert it to string
    }
}
