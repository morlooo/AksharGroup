using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Swipe : MonoBehaviour
{
    public GameObject scrollbar;
    private float[] positions;  // Store positions for each child
    private int currentIndex = 0;

    // Adjustable speed for smooth scrolling
    public float scrollSpeed = 0.1f;

    void Start()
    {
        UpdatePositions();  // Call to update positions when the scene starts
    }

    // This function updates the positions array based on the child count
    private void UpdatePositions()
    {
        int childCount = transform.childCount;
        if (childCount == 0) return;  // If no children, do nothing

        positions = new float[childCount];
        float distance = 1f / (childCount - 1);

        for (int i = 0; i < childCount; i++)
        {
            positions[i] = distance * i;
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePositions();  // Keep positions updated during runtime in case of any changes

        // Check for swipe gestures
        if (Input.GetMouseButtonDown(0))
        {
            // Store the initial touch position
            Vector2 startTouch = Input.mousePosition;
            StartCoroutine(SwipeCoroutine(startTouch));
        }
    }

    private IEnumerator SwipeCoroutine(Vector2 startTouch)
    {
        while (Input.GetMouseButton(0))
        {
            yield return null; // Wait until the next frame
        }

        // Calculate the swipe direction
        Vector2 endTouch = Input.mousePosition;
        float swipeDistance = endTouch.x - startTouch.x;

        if (swipeDistance > 50) // Swipe right
        {
            currentIndex = Mathf.Clamp(currentIndex - 1, 0, positions.Length - 1);
        }
        else if (swipeDistance < -50) // Swipe left
        {
            currentIndex = Mathf.Clamp(currentIndex + 1, 0, positions.Length - 1);
        }

        // Smoothly scroll to the new position
        StartCoroutine(SmoothScrollTo(positions[currentIndex]));
    }

    private IEnumerator SmoothScrollTo(float targetValue)
    {
        float startValue = scrollbar.GetComponent<Scrollbar>().value;
        float elapsedTime = 0;

        while (elapsedTime < 1f)
        {
            elapsedTime += Time.deltaTime / scrollSpeed; // Adjust the speed here
            scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(startValue, targetValue, elapsedTime);
            yield return null; // Wait until the next frame
        }

        scrollbar.GetComponent<Scrollbar>().value = targetValue; // Ensure it reaches the target
    }
}
