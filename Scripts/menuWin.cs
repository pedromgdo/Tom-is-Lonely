using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuWin : MonoBehaviour
{
    public GameObject winObject;
    private void Awake() {
        if (PlayerPrefs.GetInt("PlayerWon", 0) == 1) winObject.SetActive(true); else winObject.SetActive(false);
    }
}
