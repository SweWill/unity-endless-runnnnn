using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        // This function is called when the object is created.
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // This function is called when this object collides with another object that has a Collider2D component.
        // The argument 'collision' contains information about the other object.

        if (collision.tag == "Border")
        {
            // If the tag of the other object is "Border", we destroy this obstacle.
            Destroy(this.gameObject);
        }

        else if (collision.tag == "Player")
        {
            Destroy(player.gameObject);
        }
    }
}
