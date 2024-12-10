using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class PlayersPanel: MonoBehaviour
{
    [SerializeField] TMP_Text numberText;
    [SerializeField] TMP_Text nameText;
    [SerializeField] TMP_Text scoreText;
    public string ScoreText => scoreText.text;

    public void Set(string number, string name, string score)
    {
        numberText.text = number;
        nameText.text = name;
        scoreText.text = score;
    }
}
