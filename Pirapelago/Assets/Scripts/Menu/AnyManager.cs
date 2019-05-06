using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnyManager : MonoBehaviour
{
    public static AnyManager anyManager;
    public float time;
    public int score;
    public int selectedWeapon;
    bool gameStarted;
    void Awake()
    {
        if (!gameStarted)
        {
            anyManager = this;
            SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
            gameStarted = true;
        }
    }

    public void LoadScene(int scene, int unload)
    {
        StartCoroutine(Load(scene, unload));
    }

    public void UnloadScene(int scene)
    {
        StartCoroutine(Unload(scene));
    }

    IEnumerator Unload(int scene)
    {
        yield return null;
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByBuildIndex(scene));
    }

    IEnumerator Load(int scene, int unload)
    {
        if (unload != 100)
        {
            UnloadScene(unload);
        }
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(0));
        yield return null;
        SceneManager.LoadScene(scene, LoadSceneMode.Additive);
        yield return null;
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(scene));
        

        //SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(scene));

        yield return null;
    }

}
