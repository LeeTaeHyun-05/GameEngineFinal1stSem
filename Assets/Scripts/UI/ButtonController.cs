using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public GameObject ScrollView;
   

    public void ScoreViewOpem()
    {
        ScrollView.SetActive(true);
    }
    public void ScoreViewClose()
    {
        ScrollView.SetActive(false);
    }

    public void Gamestart()
    {
        SceneManager.LoadScene("PlayScene");
    }

    public void GameEnd()
    {
        Application.Quit();
    }

   public void Tomain()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
