using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UImanager : MonoBehaviour
{
    public static UImanager instance;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI deathsText;

    private void Awake() {
        if (instance != null) {
            Destroy(gameObject);
            return;
        }
        else {
            instance = this;
        }
        updateTexts();
    }

    public void updateTexts() {
        levelText.text = "Level " + SceneManager.GetActiveScene().buildIndex;
        deathsText.text = PlayerPrefs.GetInt("nrDeaths", 0) + " Deaths";
    }
}
