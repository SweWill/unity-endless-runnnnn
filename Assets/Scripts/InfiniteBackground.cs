// This script controls the scrolling of a 2D background by updating its texture offset
using UnityEngine;
using System.Collections;

public class InfiniteBackground : MonoBehaviour
{
    // The speed at which the background scrolls
    [SerializeField] private float scrollSpeed = 1f;

    // The renderer component of the background object
    [SerializeField] private Renderer backgroundRenderer;

    // Start is called before the first frame update
    private void Start()
    {
        // Start the coroutine to continuously scroll the background
        StartCoroutine(ScrollBackground());
    }

    // The coroutine that continuously scrolls the background
    private IEnumerator ScrollBackground()
    {
        // Loop forever
        while (true)
        {
            // Calculate the horizontal offset based on time and speed
            float xOffset = Time.time * scrollSpeed % 1f;

            // Set the texture offset of the background
            backgroundRenderer.material.SetTextureOffset("_MainTex", new Vector2(xOffset, 0f));

            // Wait for the next frame before continuing the loop
            yield return null;
        }
    }
}
