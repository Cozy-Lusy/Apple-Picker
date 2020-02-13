using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScore : MonoBehaviour
{
    public static int Score = 0;

    private void Awake()
    {
        //Если значение HighScore уже существует в PlayerPrefs, прочитать его
        if (PlayerPrefs.HasKey("HighScore"))
        {
            Score = PlayerPrefs.GetInt("HighScore");
        }
        PlayerPrefs.SetInt("HighScore", Score); //Сохранить высшее достижение в PlayerPrefs
    }

    private void Update()
    {
        TextMeshProUGUI gt = GetComponent<TextMeshProUGUI>();
        gt.text = "High Score: " + Score;

        //Обновить HighScore в PlayerPrefs, если необходимо
        if (Score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", Score);
        }
    }
}
