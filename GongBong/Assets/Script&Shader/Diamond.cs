using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    void Update()
    {
        // Rotasi diamond
        transform.Rotate(Vector3.up, 50 * Time.deltaTime); // Putar diamond
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Cek jika pemain mengambil diamond
        {
            // Dapatkan komponen LifeCount dari pemain
            LifeCount lifeCount = other.GetComponent<LifeCount>();
            if (lifeCount != null)
            {
                lifeCount.GainLife(); // Pulihkan nyawa saat mengambil diamond
            }

            // Dapatkan komponen HealthBar jika ada untuk menambah kesehatan (opsional)
            HealthBar healthBar = other.GetComponent<HealthBar>();
            if (healthBar != null)
            {
                healthBar.GainHealth(20); // Pulihkan kesehatan saat mengambil diamond
            }

            Destroy(gameObject); // Hapus diamond setelah diambil
        }
    }
}
