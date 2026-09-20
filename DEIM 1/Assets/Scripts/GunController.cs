using UnityEngine;

public class GunController : MonoBehaviour
{
    public Transform spawnBullet;
    public GameObject bulletPrefab;

    public float shotForce = 1500f;
    [SerializeField] float breathAmount = 0.005f;
    [SerializeField] float breathSpeed = 1.5f;
    [SerializeField] float recoilAmount = 0.02f;
    [SerializeField] float maxRecoil = 0.05f;
    [SerializeField] float recoilReturnSpeed = 0.25f;
    [SerializeField] float shotCooldown = 0.5f;
    [SerializeField] int shotSoundIndex = 0;

    Vector3 initialLocalPosition;
    float breathTime;
    float recoilOffset;
    float nextShotTime;

    void Awake()
    {
        initialLocalPosition = transform.localPosition;
        breathTime = Random.Range(0f, Mathf.PI * 2f);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateWeaponMovement();

        if (Input.GetMouseButtonDown(0) && GameManager.Instance.ammoCount > 0 && Time.time >= nextShotTime)
        {
            Shoot();
        }   
    }

    void Shoot()
    {
        nextShotTime = Time.time + shotCooldown;
        recoilOffset = Mathf.Min(recoilOffset + recoilAmount, maxRecoil);

        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlaySound(shotSoundIndex);
        }

        GameManager.Instance.ammoCount--;
        GameManager.Instance.textAmmo.text = GameManager.Instance.ammoCount.ToString();
        
        GameObject bullet = Instantiate(bulletPrefab, spawnBullet.position, spawnBullet.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(spawnBullet.forward * shotForce);
        Destroy(bullet, 1f);
    }

    void UpdateWeaponMovement()
    {
        breathTime += breathSpeed * Time.deltaTime;
        recoilOffset = Mathf.MoveTowards(recoilOffset, 0f, recoilReturnSpeed * Time.deltaTime);

        Vector3 localPosition = initialLocalPosition;
        localPosition.y += Mathf.Sin(breathTime) * breathAmount;
        localPosition.z -= recoilOffset;
        transform.localPosition = localPosition;
    }
}
