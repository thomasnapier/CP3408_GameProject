using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PoolController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            nextLevel();
        }
    }

    public void nextLevel()
    {
        AnyManager.anyManager.time = TimeManager.timer;
        ScoreManager.score += GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>().Money;
        AnyManager.anyManager.score = ScoreManager.score;
        AnyManager.anyManager.selectedWeapon = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStats>().WeaponType;
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            GameObject.Find("LevelChanger").GetComponent<LevelChanger>().FadeToLevel(3);
        }
        else
        {
            GameObject.Find("LevelChanger").GetComponent<LevelChanger>().FadeToLevel(2);
        }
    }
}
