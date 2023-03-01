// Importing necessary libraries for the code.
using System.Collections;
using UnityEngine;

// Declaring the class for camera movement.
public class CamMove : MonoBehaviour
{
    // Declaring the public float variable to set the speed of the camera.
    public float speedOfCam;

    // Coroutine method called Start, which will run when the script is enabled.
    private IEnumerator Start()
    {
        // Infinite loop that runs until the script is disabled.
        while (true)
        {
            // Wait for the next physics update to ensure smooth movement.
            yield return new WaitForFixedUpdate();

            // Calls the MoveCamera method to move the camera.
            MoveCamera();
        }
    }

    // Method to move the camera.
    private void MoveCamera()
    {
        // Changes the position of the camera by adding to the x coordinate.
        transform.position += new Vector3(speedOfCam * Time.fixedDeltaTime, 0, 0);
    }
}
