using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int bIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("currentLevelID", bIndex);
    }
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) SceneManager.LoadScene(0);
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.P)) ScreenCapture.CaptureScreenshot("screenshot" + System.DateTime.Now.ToFileTime() + ".png");
#endif
    }
}
