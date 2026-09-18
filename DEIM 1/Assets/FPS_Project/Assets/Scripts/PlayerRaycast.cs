using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerRaycast : MonoBehaviour
{
    public float distancia = 10f;
    Transform shadow;

    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(
            transform.position,
            transform.forward,
            out hit,
            distancia))
        {
            Debug.DrawRay(
                transform.position,
                transform.forward * hit.distance,
                Color.green
            );

            ////Debug.Log("Apuntando a: " + hit.collider.name);
            ////VERSION ANTIGUA
            //if (Input.GetKeyDown(KeyCode.E))
            //{
            //    Debug.Log("Interactúo con " + hit.collider.name);
            //}
            //VERSION NUEVA
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                Debug.Log(
                    "He apuntado a: " +
                    hit.collider.name
                );
            }

            if (hit.collider.CompareTag("cubeToPoint"))
            {
                shadow =hit.collider.transform.GetChild(0);
                shadow.gameObject.SetActive(true);
            }
            else
            {
                if (shadow)
                {
                shadow.gameObject.SetActive(false);
                }
            }
        }
        else
        {
            Debug.DrawRay(
                transform.position,
                transform.forward * distancia,
                Color.red
            );
        }
    }
}