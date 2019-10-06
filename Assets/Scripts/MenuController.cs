using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuController : MonoBehaviour
{
#if UNITY_EDITOR
    private void Update() {
        if (Input.GetKeyDown(KeyCode.P)) ScreenCapture.CaptureScreenshot("screenshot" + System.DateTime.Now.ToFileTime() + ".png");
    }
#endif
    public void loadByIndex(int index = 0) {
        SceneManager.LoadScene(index);
    }
    public void loadCurrentLevel() {
        int index = PlayerPrefs.GetInt("currentLevelID", 1);
        SceneManager.LoadScene(index);
    }
    public void QuitGame() {
        Application.Quit();
        Debug.Log("Quitting game");
    }
    public static void reloadCurrentLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void resetPrefs() {
        PlayerPrefs.DeleteAll();
    }
    public void openTwitter() {
        Application.OpenURL("https://twitter.com/Cold_Hours");
    }
}
