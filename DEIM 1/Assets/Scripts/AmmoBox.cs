using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 90f;
    [SerializeField] float floatHeight = 0.25f;
    [SerializeField] float floatSpeed = 2f;

    Vector3 initialLocalPosition;
    float floatTime;

    public int ammo = 10;

    void Awake()
    {
        initialLocalPosition = transform.localPosition;
        floatTime = Random.Range(0f, Mathf.PI * 2f);
    }

    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime, Space.Self);

        floatTime += floatSpeed * Time.deltaTime;
        Vector3 localPosition = initialLocalPosition;
        localPosition.y += Mathf.Sin(floatTime) * floatHeight;
        transform.localPosition = localPosition;
    }
}
