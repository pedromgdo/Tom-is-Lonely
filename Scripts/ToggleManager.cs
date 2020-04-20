using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class ToggleManager : MonoBehaviour
{
    public bool isSound = false;
    public Toggle m_toggle;
    public GameObject active;
    public GameObject inactive;
    // Start is called before the first frame update
    void Start()
    {
        if (m_toggle == null) m_toggle = GetComponent<Toggle>();
        valueChanged();
    }

    public void valueChanged() {
        if (m_toggle.isOn) {
            active.SetActive(true);
            inactive.SetActive(false);
            if (isSound) AudioListener.volume = 1f;
        }
        else {
            active.SetActive(false);
            inactive.SetActive(true);
            if (isSound) AudioListener.volume = 0f;
        }
    }

}
