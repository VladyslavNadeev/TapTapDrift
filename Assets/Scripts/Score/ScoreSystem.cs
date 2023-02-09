using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _highscoreText;
    [SerializeField] private TextMeshProUGUI _mainScoreText;
    [SerializeField] private TextMeshProUGUI _circleScoreText;

    [SerializeField] private TextMeshProUGUI _crystalScoreText;

    public static int CircleScore = 0;
    public static int CrystalScore;
    public static int mainScore;
    private int highscore;

    private void Start()
    {
        mainScore = 0;
        CrystalScore = 0;
        CircleScore = 0;
    }

    private void Update()
    {
        _circleScoreText.text = $"+{CircleScore}";

        _crystalScoreText.text = ": " + CrystalScore.ToString();


        _mainScoreText.text = "Score: " + mainScore.ToString();





        //if(PlayerPrefs.GetInt("mainScore") <= highscore)
        //{
            //PlayerPrefs.SetInt("mainScore", highscore);
        //}

        //_highscoreText.text = "HighScore: " + PlayerPrefs.GetInt("mainScore").ToString();
    }
}
