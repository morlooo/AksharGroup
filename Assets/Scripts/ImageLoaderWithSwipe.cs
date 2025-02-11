using UnityEngine;
using UnityEngine.UI;

public class ImageLoaderWithSwipe : MonoBehaviour
{
    public Transform contentPanel; // Assign the ScrollView Content panel
    public GameObject imagePrefab; // Assign an Image prefab with an Image component
    public string folderName = "default_folder"; // Set folder name in Inspector or at runtime

    void Start()
    {
        LoadImages(folderName);
    }

    public void LoadImages(string folder)
    {
        // Load images from the specified folder in Resources
        Sprite[] sprites = Resources.LoadAll<Sprite>(folder);

        if (sprites.Length == 0)
        {
            Debug.LogError("No images found in Resources/" + folder);
            return;
        }

        // Clear existing images before loading new ones
        foreach (Transform child in contentPanel)
        {
            Destroy(child.gameObject);
        }

        foreach (Sprite sprite in sprites)
        {
            GameObject newImage = Instantiate(imagePrefab, contentPanel);
            newImage.GetComponent<Image>().sprite = sprite;
        }
    }

    // Call this function to change the folder at runtime
    public void SetFolder(string newFolderName)
    {
        folderName = newFolderName;
        LoadImages(folderName);
    }
}