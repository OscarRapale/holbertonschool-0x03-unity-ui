using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayMaze()
    {
        // Load the maze scene
        SceneManager.LoadScene("maze");
    }

	public void QuitMaze()
	{
		Debug.Log("Quit Game");

		// Quit the application
		Application.Quit();
	}
}
