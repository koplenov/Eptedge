using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Exit() => Application.Quit();
    public void GoToMenu() => SceneManager.LoadScene("Menu");
    public void ToGarage()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Garage");
    }

    public void Play() => SceneManager.LoadScene("SampleScene");
    public void ToggleSound()
    {
        Utils.SetSoundEnabled(!Utils.IsSoundEnabled());
        FindObjectOfType<AudioControll>(true).ReAwakeStart();
    }
}

public static class Utils
{
    private const string SoundEnabled = "SoundEnabled"; 
    public static bool IsSoundEnabled()
    {
        var currentState = PlayerPrefs.GetString(SoundEnabled, "false");
        return currentState != "false";
    }

    public static void SetSoundEnabled(bool state)
    {
        PlayerPrefs.SetString(SoundEnabled, state.ToString().ToLower());
    }
}
