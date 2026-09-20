using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnController : MonoBehaviour
{
	[SerializeField] PlayerActions playerActions;

	void Awake()
	{
		if (playerActions == null)
		{
			playerActions = FindFirstObjectByType<PlayerActions>();
		}
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.E) && playerActions != null && playerActions.IsLookingAtRespawn)
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}
}
