using UnityEngine;
using UnityEngine.SceneManagement;  // Required for scene loading

public class SceneLoader : MonoBehaviour
{
    // This method will be called when the button is clicked
    public void LoadScene(string sceneName)
    {
        Debug.Log("click");
        // Load the scene by name
        SceneManager.LoadScene(sceneName);
       // Debug.Log("click");
    }
}
