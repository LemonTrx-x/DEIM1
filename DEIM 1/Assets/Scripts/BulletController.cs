using UnityEngine;

public class BulletController : MonoBehaviour
{
    PlayerActions playerActions;
    
    void Awake()
    {
        playerActions = FindFirstObjectByType<PlayerActions>();
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (playerActions == null)
            {
                playerActions = FindFirstObjectByType<PlayerActions>();
            }
        
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            playerActions.enemyCount++;
            GameManager.Instance.BoxDestroyed();
        }

        if (collision.gameObject.CompareTag("Door"))
        {
            if (playerActions == null)
            {
                playerActions = FindFirstObjectByType<PlayerActions>();
            }

            if (playerActions != null)
            {
                playerActions.OpenDoor();
            }

            Destroy(collision.gameObject);
        }
    }
}
