using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;
    private int levelToLoad;

    public void FadeToLevel (int levelIndex)
    {
        Time.timeScale = 1;
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete ()
    {

        GameObject[] temps = GameObject.FindGameObjectsWithTag("Temp");
        for (int i = 0; i < temps.Length; i++)
        {
            Destroy(temps[i]);
        }
        if (levelToLoad == 2 && SceneManager.GetActiveScene().buildIndex == 0)
        {
            AnyManager.anyManager.LoadScene(levelToLoad, 1);
        } else
        {
            AnyManager.anyManager.LoadScene(levelToLoad, SceneManager.GetActiveScene().buildIndex);
        }
    }
}
