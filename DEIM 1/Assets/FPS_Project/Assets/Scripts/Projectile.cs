using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float lifeTime = 5f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(
            "Impacto contra: " +
            collision.gameObject.name
        );

       // Destroy(gameObject);
    }
}