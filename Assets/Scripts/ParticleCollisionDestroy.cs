// Import the necessary Unity Engine package for this script.
using UnityEngine;

// Define a class named ParticleCollisionDestroy.
public class ParticleCollisionDestroy : MonoBehaviour
{
    // Serialize a private string variable named "destroyTag" that specifies the tag of the GameObject to be destroyed on collision.
    [SerializeField] private string destroyTag = "Player";

    // Define a private method that is called when the gameobject is hit by a particle collision.
    private void OnParticleCollision(GameObject other)
    {
        // Check if the GameObject hit by the particle collision has the same tag as "destroyTag".
        if (other.CompareTag(destroyTag))
        {
            // If the tag of the GameObject matches "destroyTag", destroy the GameObject.
            Destroy(other);
        }
    }
}
