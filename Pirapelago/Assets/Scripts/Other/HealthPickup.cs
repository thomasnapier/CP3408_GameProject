using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPickup : MonoBehaviour
{
    private CharacterStats stats;
    private bool pickedUp = false;
    public AudioClip pickUpSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!pickedUp)
            {
                SoundManager.instance.PlaySingle(pickUpSound);
                pickedUp = true;
                stats = collision.gameObject.GetComponent<CharacterStats>();
                if (stats.CurrentHealth < stats.MaxHealth / 4 * 3)
                {
                    stats.CurrentHealth += stats.MaxHealth / 4;
                }
                else
                {
                    stats.CurrentHealth = stats.MaxHealth;
                }
                GameObject.Find("Canvas").transform.Find("healthSlider").GetComponent<Slider>().value = stats.CurrentHealth;
                Destroy(gameObject, 0);
            }
        }
    }
}
