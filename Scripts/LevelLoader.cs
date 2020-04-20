using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public int indexToLoad;

    public static void LoadLevel(int index = 0) {
        SceneManager.LoadScene(index);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Player") {
            if (!collision.gameObject.GetComponent<PlayerMovement>().blockMovement) {
                AudioManager.instance.Play("win_1");
                if (indexToLoad == 0) PlayerPrefs.SetInt("PlayerWon", 1);
                LoadLevel(indexToLoad);
            }
        }
    }
}
