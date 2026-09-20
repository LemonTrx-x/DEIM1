using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerActions : MonoBehaviour
{
    public GameObject openDoor;
    public float enemyCount = 0;
    public GameObject openDoor2;
    public int currentAmmo = 10;
    [SerializeField] Camera playerCamera;
    [SerializeField] TMP_Text[] respawnTexts;
    [SerializeField] float respawnDistance = 3f;
    public bool IsLookingAtRespawn { get; private set; }

    private void Awake()
    {
        Cursor.visible = false;
    }

    private void OnApplicationFocus(bool hasFocus)
    {
        Cursor.visible = false;
    }

    private void Start()
    {
        if (playerCamera == null)
        {
            playerCamera = Camera.main;
        }

        foreach (TMP_Text respawnText in respawnTexts)
        {
            if (respawnText == null)
            {
                continue;
            }

            respawnText.text = "Respawn (E)";
            respawnText.gameObject.SetActive(false);
        }

        if (openDoor == null)
        {
            openDoor = GameObject.FindGameObjectWithTag("Door");
        }

        if (openDoor != null)
        {
            openDoor.SetActive(true);
            openDoor2.SetActive(true);
        }
    }

    public void OpenDoor()
    {
        if (openDoor != null)
        {
            openDoor.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ammo"))
        {
            GameManager.Instance.ammoCount += other.gameObject.GetComponent<AmmoBox>().ammo;
            GameManager.Instance.textAmmo.text = GameManager.Instance.ammoCount.ToString();
            Destroy(other.gameObject);
        }
    }

    void Update()
    {
        RespawnRaycast();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            Debug.Log("Quit Game");
        }

        if (enemyCount >= 10)
        {
            openDoor2.SetActive(false);
        }

        if (enemyCount >= 20)
        {
            SceneManager.LoadScene(1);
        }
    }

    void RespawnRaycast()
    {
        if (playerCamera == null)
        {
            IsLookingAtRespawn = false;
            SetRespawnTextsActive(false);
            return;
        }

        bool isLookingAtRespawn = Physics.Raycast(
            playerCamera.transform.position,
            playerCamera.transform.forward,
            out RaycastHit hit,
            respawnDistance
        ) && hit.collider.CompareTag("Respawn");

        IsLookingAtRespawn = isLookingAtRespawn;
        SetRespawnTextsActive(isLookingAtRespawn);
    }

    void SetRespawnTextsActive(bool isActive)
    {
        foreach (TMP_Text respawnText in respawnTexts)
        {
            if (respawnText != null)
            {
                respawnText.gameObject.SetActive(isActive);
            }
        }
    }
}
