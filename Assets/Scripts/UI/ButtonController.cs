using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonController : MonoBehaviour
{
    public TMP_InputField nameInput;
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
        string inputName = nameInput.text;
        string finalName = string.IsNullOrWhiteSpace(inputName) ? "플레이어" : inputName;
        PlayerPrefs.SetString("PlayerName", finalName);
        Debug.Log($"[게임 시작] 저장된 이름: {finalName}");
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
