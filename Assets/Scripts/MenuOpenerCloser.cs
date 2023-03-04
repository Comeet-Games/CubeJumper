using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOpenerCloser : MonoBehaviour
{
    public Animator anim;
    public GameObject settingsButton;
    public GameObject quitButton;
    public bool isMenuOpen = false;

    public void OpenCloseMenu()
    {
        if (!isMenuOpen)
        {
            settingsButton.SetActive(true);
            quitButton.SetActive(true);
            isMenuOpen = true;
            anim.Play("Drop-downMenu");
        }
        else if (isMenuOpen)
        {
            Invoke("DeactiveSettingsAndQuitButtons", 0.75f);
            isMenuOpen = false;
            anim.Play("Drop-downMenuUp");
        }
    }

    public void CloseMenu()
    {
        if (isMenuOpen)
        {
            Invoke("DeactiveSettingsAndQuitButtons", 0.75f);
            isMenuOpen = false;
            anim.Play("Drop-downMenuUp");
        }
    }

    void DeactiveSettingsAndQuitButtons()
    {
        settingsButton.SetActive(false);
        quitButton.SetActive(false);
    }
}
