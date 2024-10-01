using UnityEngine;

public class Destructible : MonoBehaviour
{
    public float health = 100f; // Jumlah darah
    public GameObject destructionEffect; // Prefab efek hancur

    public void TakeDamage(float amount)
    {
        health -= amount; // Kurangi darah
        if (health <= 0)
        {
            DestroyCube(); // Hancurkan cube jika darah habis
        }
    }

    private void DestroyCube()
    {
        if (destructionEffect != null)
        {
            Instantiate(destructionEffect, transform.position, transform.rotation); // Instantiate efek
        }
        Destroy(gameObject); // Hancurkan cube
    }

}
