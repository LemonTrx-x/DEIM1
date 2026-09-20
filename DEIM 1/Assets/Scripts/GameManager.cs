using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public TextMeshProUGUI textAmmo;
    public TextMeshProUGUI textBoxes;
    public int ammoCount = 10;
    public int BoxesDestroyed = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        textAmmo.text = ammoCount.ToString();
        UpdateBoxesText();
    }

    public void BoxDestroyed()
    {
        BoxesDestroyed++;
        UpdateBoxesText();
    }

    void UpdateBoxesText()
    {
        if (textBoxes != null)
        {
            textBoxes.text = BoxesDestroyed.ToString();
        }
    }
}
