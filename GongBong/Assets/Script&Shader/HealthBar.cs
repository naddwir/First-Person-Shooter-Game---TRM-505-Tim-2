using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image fillBar;
    public float health = 100f;
    public float maxHealth = 100f;

    public void LoseHealth(int value)
    {
        if (health <= 0) return;

        health -= value;
        fillBar.fillAmount = health / maxHealth;

        if (health <= 0)
        {
            Debug.Log("You Died");
            // Tambahkan logika untuk mengakhiri permainan jika diperlukan
        }
    }

    public void GainHealth(int value)
    {
        if (health <= 0) return;

        health += value;
        if (health > maxHealth) health = maxHealth;
        fillBar.fillAmount = health / maxHealth;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            LoseHealth(20); // Untuk pengujian
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HealthDiamond"))
        {
            GainHealth(20);
            Destroy(other.gameObject);

            // Memanggil diamond spawner untuk memulai coroutine
            DiamondSpawner spawner = FindObjectOfType<DiamondSpawner>();
            if (spawner != null)
            {
                spawner.OnDiamondCollected();
            }
        }
    }
}
