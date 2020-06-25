using System.Collections;
using System.Collections.Generic;
using System.Management.Instrumentation;
using TMPro;
using UnityEngine;

public class Enemy_DeathCount : MonoBehaviour
{
    public static Enemy_DeathCount instance = null;

    [SerializeField] private PauseButton_Pause Menu;
    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private TextMeshProUGUI highScore;
    [SerializeField] private TextMeshProUGUI currentScore;

    private int enemyDead;

    private void Start()
    {
        instance = this;
    }

    public static void EnemyDeath()
    {
        instance.enemyDead++;
        instance.currentScore.text = instance.enemyDead.ToString();
    }

    public static void SetupCount()
    {
        int maxScore = 0;

        if (PlayerPrefs.HasKey("Score"))
        {
            maxScore = PlayerPrefs.GetInt("Score");

            if(instance.enemyDead > maxScore)
            {
                maxScore = instance.enemyDead;
                PlayerPrefs.SetInt("Score", instance.enemyDead);
            }
        }
        else
        {
            maxScore = instance.enemyDead;
            PlayerPrefs.SetInt("Score", maxScore);
        }

        instance.score.text = instance.enemyDead.ToString();
        instance.highScore.text = maxScore.ToString();

        instance.StartCoroutine(instance.MenuTimer());
    }

    IEnumerator MenuTimer()
    {
        yield return new WaitForSeconds(15);
        Menu.OpenMenu();
    }
}
