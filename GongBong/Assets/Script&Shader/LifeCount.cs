using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeCount : MonoBehaviour
{
    public Image[] lives;
    public int livesRemaining = 5;
    private DiamondSpawner diamondSpawner; // Referensi ke DiamondSpawner

    public void LoseLife()
    {
        if (livesRemaining == 0) return;

        livesRemaining--;
        lives[livesRemaining].enabled = false;

        if (livesRemaining == 0)
        {
            Debug.Log("YOU LOSE");
            // Tambahkan logika untuk mengakhiri permainan jika diperlukan
        }
    }

    public void GainLife()
    {
        // Hanya tambah nyawa jika kesehatan masih ada dan nyawa belum penuh
        HealthBar healthBar = GetComponent<HealthBar>();
        if (healthBar != null && healthBar.health > 0)
        {
            if (livesRemaining < lives.Length) // Cek apakah masih ada slot untuk nyawa
            {
                lives[livesRemaining].enabled = true; // Tampilkan gambar nyawa yang baru
                livesRemaining++; // Tambah jumlah nyawa
            }
        }
    }

    private void Start()
    {
        // Mendapatkan referensi ke DiamondSpawner
        diamondSpawner = FindObjectOfType<DiamondSpawner>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            LoseLife(); // Untuk pengujian
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HealthDiamond"))
        {
            GainLife(); // Pulihkan satu nyawa saat mengambil diamond
            Destroy(other.gameObject); // Hapus diamond setelah diambil

            // Memanggil diamond spawner untuk memulai coroutine
            if (diamondSpawner != null)
            {
                diamondSpawner.OnDiamondCollected();
            }

        }
        if (other.CompareTag("Enemy"))
        {
            LoseLife(); // Pulihkan satu nyawa saat mengambil diamond
            
        }
    }
}
