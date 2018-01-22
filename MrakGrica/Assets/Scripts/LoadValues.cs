using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadValues : MonoBehaviour
{
    public Text Health, Score;

    void Awake()
    {
        Score.text = "POINTS: " + Movement.ScoreN;
        Health.text = System.Convert.ToInt32(PlayCont.Health).ToString();
    }
}
