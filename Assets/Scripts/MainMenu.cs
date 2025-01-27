using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
	public Material trapMat;
	public Material goalMat;
	public Toggle colorblindMode;

    public void PlayMaze()
    {

		// Check if Colorblind Mode is toggled on
		if (colorblindMode.isOn)
		{
			// Change the colors for trap and goal materials
			trapMat.color = new Color32(255, 112, 0, 255); // Bright orange
			goalMat.color = Color.blue; // Blue
		}
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
