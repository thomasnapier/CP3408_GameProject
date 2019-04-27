using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public void pauseMenu()
    {
        GameObject.Find("Canvas").transform.Find("PauseMenu").gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void unpauseMenu()
    {
        GameObject.Find("Canvas").transform.Find("PauseMenu").gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
