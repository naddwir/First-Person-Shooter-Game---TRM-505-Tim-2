using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondSpawner : MonoBehaviour
{
    public GameObject diamondPrefab; // Prefab diamond
    private GameObject currentDiamond; // Menyimpan diamond yang saat ini ada
    private float spawnDelay = 120f; // Delay spawn setelah diambil (2 menit)

    void Start()
    {
        SpawnDiamond(); // Spawn diamond pertama kali
    }

    void SpawnDiamond()
    {
        if (currentDiamond == null) // Pastikan tidak ada diamond yang aktif
        {
            // Tentukan posisi acak untuk diamond
            Vector3 randomPosition = new Vector3(
                Random.Range(-10f, 10f), // Sesuaikan rentang spawn
                0.2f, // Tinggi di mana diamond akan muncul
                Random.Range(-10f, 10f)
            );

            currentDiamond = Instantiate(diamondPrefab, randomPosition, Quaternion.identity);
            currentDiamond.tag = "HealthDiamond"; // Pastikan tag diamond benar
        }
    }

    public void OnDiamondCollected()
    {
        if (currentDiamond != null)
        {
            Destroy(currentDiamond); // Hapus diamond saat diambil
            StartCoroutine(RespawnDiamond()); // Mulai coroutine untuk respawn
        }
    }

    private IEnumerator RespawnDiamond()
    {
        yield return new WaitForSeconds(spawnDelay); // Tunggu selama 2 menit
        SpawnDiamond(); // Spawn diamond baru
    }
}
