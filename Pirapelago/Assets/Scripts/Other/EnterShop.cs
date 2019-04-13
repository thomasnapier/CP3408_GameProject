using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterShop : MonoBehaviour
{
    public GameObject shopUI;
    public GameObject canvas;

    bool isPaused;

    private void Awake()
    {
        canvas = GameObject.FindGameObjectWithTag("canvas");
        shopUI = canvas.transform.Find("shopUI").gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PauseGame();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            ContinueGame();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ContinueGame();
        }
    }

    public void PauseGame()
    {
        Debug.Log("is puased");
        shopUI.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }

    public void ContinueGame()
    {
        Debug.Log("is not puahsed");
        shopUI.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }
}
