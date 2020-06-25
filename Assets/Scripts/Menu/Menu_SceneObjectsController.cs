using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_SceneObjectsController : MonoBehaviour
{
    [SerializeField] private GameObject MenuObjects;
    [SerializeField] private GameObject WeaponStatsObjects;

    public void OpenGuns()
    {
        MenuObjects.SetActive(false);
        WeaponStatsObjects.SetActive(true);
    }

    public void OpenMenu()
    {
        MenuObjects.SetActive(true);
        WeaponStatsObjects.SetActive(false);
    }

    public void PlayScene()
    {
        SceneManager.LoadScene("Game");
    }

    public void MenuuScene()
    {
        SceneManager.LoadScene("Menu");
    }
}
