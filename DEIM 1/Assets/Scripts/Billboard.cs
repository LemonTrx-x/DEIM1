using UnityEngine;

public class Billboard : MonoBehaviour
{
    [SerializeField] Transform playerCamera;

    void Awake()
    {
        if (playerCamera == null && Camera.main != null)
        {
            playerCamera = Camera.main.transform;
        }
    }

    void LateUpdate()
    {
        if (playerCamera == null)
        {
            return;
        }

        transform.LookAt(playerCamera);
        transform.Rotate(0f, 180f, 0f);
    }
}
