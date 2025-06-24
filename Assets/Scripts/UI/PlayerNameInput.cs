using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerNameInput : MonoBehaviour
{
    public TMP_InputField inputField;
    public static string PlayerName { get; private set; }

    public void OnConfirmName()
    {
        PlayerName = string.IsNullOrWhiteSpace(inputField.text) ? "�÷��̾�" : inputField.text;
        PlayerPrefs.SetString("PlayerName", PlayerName); //  PlayerPrefs�� ����
        Debug.Log($"[�̸� ������] PlayerName: {PlayerName}");
        SceneManager.LoadScene("GameScene");
    }

}
