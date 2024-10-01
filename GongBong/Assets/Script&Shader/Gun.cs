using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab; // Prefab peluru
    public Transform bulletSpawnPoint; // Titik spawn peluru
    public float bulletSpeed = 20f; // Kecepatan peluru
    public float fireRate = 0.5f; // Rate tembak
    private float nextFireTime = 0f; // Waktu berikutnya bisa menembak

    void Update()
    {
        // Cek apakah player menekan tombol tembak
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate; // Set waktu berikutnya
            Shoot();
        }
    }

    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = bulletSpawnPoint.forward * bulletSpeed;
        }

        Ray ray = new Ray(bulletSpawnPoint.position, bulletSpawnPoint.forward);
        RaycastHit hit;

        Destroy(bullet, 2f);

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("Hit: " + hit.collider.name);
            Destructible destructible = hit.collider.GetComponent<Destructible>();
            if (destructible != null)
            {
                destructible.TakeDamage(20f); // Misalnya, setiap peluru memberikan 20 damage
            }
        }
    }

}
