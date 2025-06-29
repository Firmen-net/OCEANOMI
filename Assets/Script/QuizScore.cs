using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class QuizScore : MonoBehaviour
{
    public TextMeshProUGUI text;
    private int score;

    public List<Image> levelimg;
    public Image scoreIMG;
    public Sprite score1;
    public Sprite score2;
    public Sprite score3;
    public Sprite score4;
    public Sprite score5;
    public Sprite score6;

    private void OnEnable()
    {
        ResetScore();
    }

    public void AddScore()
    {
        score += 20;

        text.text = "Nilai : " + score.ToString();
    }

    public void ResetScore()
    {
        score = 0;
        text.text = "Nilai : 0";
        foreach (var item in levelimg)
        {
            item.color = Color.white;
        }
    }

    public void finalizescore()
    {
        switch (score)
        {
            case 0:
                scoreIMG.sprite = score1;
                break;

            case 20:
                scoreIMG.sprite = score2;
                break;

            case 40:
                scoreIMG.sprite = score3;
                break;

            case 60:
                scoreIMG.sprite = score4;
                break;

            case 80:
                scoreIMG.sprite = score5;
                break;

            case 100:
                scoreIMG.sprite = score6;
                break;

            default:
                break;
        }
    }
}