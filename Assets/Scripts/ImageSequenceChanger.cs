using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ImageSequenceChanger : MonoBehaviour
{
    public Image displayImage; // Assign your UI Image component in the Inspector
    public Sprite[] imageSequence; // Drag and drop your images here
    public float changeInterval = 15f; // Time in seconds

    private int currentIndex = 0;

    void Start()
    {
        if (imageSequence.Length > 0)
        {
            StartCoroutine(ChangeImageRoutine());
        }
    }

    IEnumerator ChangeImageRoutine()
    {
        while (true)
        {
            displayImage.sprite = imageSequence[currentIndex];
            currentIndex = (currentIndex + 1) % imageSequence.Length;
            yield return new WaitForSeconds(changeInterval);
        }
    }
}
