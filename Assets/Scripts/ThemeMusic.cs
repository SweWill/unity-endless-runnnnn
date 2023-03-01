using UnityEngine;

public class ThemeMusic : MonoBehaviour
{
    private static ThemeMusic instance;

    private void Awake()
    {
        // If there is no other instance of the class, set this as the instance and don't destroy on scene changes.
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        // If there is another instance of the class, destroy this instance to maintain the singleton pattern.
        else
        {
            Destroy(gameObject);
        }
    }
}
