using UnityEngine;

public class Billboard : MonoBehaviour
{
    private Camera mainCamera;

    [SerializeField] private bool onlyY = false;
    [SerializeField] private bool invert = false;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void LateUpdate()
    {
        if (mainCamera == null)
            return;

        Vector3 direction =
            mainCamera.transform.position - transform.position;

        // Si queremos que solo gire horizontalmente
        if (onlyY)
            direction.y = 0;

        if (direction.sqrMagnitude > 0.001f)
        {
            transform.rotation =
                Quaternion.LookRotation(
                    direction,
                    mainCamera.transform.up
                );
        }

        // Por si el texto aparece del revés
        if (invert)
            transform.Rotate(0, 180f, 0);
    }
}