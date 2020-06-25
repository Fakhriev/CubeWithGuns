using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseButton_Pause : MonoBehaviour
{
    [SerializeField] private Button btn_Pause;
    [SerializeField] private Button btn_Resume;
    [SerializeField] private Button btn_Menu;
    [SerializeField] private Button btn_Menu2;
    [SerializeField] private Button btn_Restart;

    [SerializeField] private GameObject pauseThings;
    [SerializeField] private GameObject joyStick;

    private void Start()
    {
        btn_Pause.onClick.AddListener(StartPause);
        btn_Resume.onClick.AddListener(ResumeGame);

        btn_Menu.onClick.AddListener(OpenMenu);
        btn_Menu2.onClick.AddListener(OpenMenu);
        btn_Restart.onClick.AddListener(RestartScene);
    }

    private void StartPause()
    {
        Time.timeScale = 0;
        pauseThings.SetActive(true);

        btn_Pause.gameObject.SetActive(false);
        joyStick.SetActive(false);
    }

    private void ResumeGame()
    {
        Time.timeScale = 1;
        pauseThings.SetActive(false);

        btn_Pause.gameObject.SetActive(true);
        joyStick.SetActive(true);
    }

    public void OpenMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menuu");
    }

    public void RestartScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
