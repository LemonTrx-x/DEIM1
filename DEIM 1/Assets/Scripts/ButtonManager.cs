using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    private void Start()
    {
        ShowCursor();
    }

    public void ShowCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void RestartGame()
    {
        ShowCursor();
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        ShowCursor();
        Application.Quit();
        Debug.Log("Quit Game");
    }
}
