using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] GameObject destroyedVFX;
    GameSceneManager gameSceneManager;

    void Start()
    {
        gameSceneManager = FindFirstObjectByType<GameSceneManager>();       // storing the class in this variable 
    }

    void OnTriggerEnter(Collider other)
    {
        gameSceneManager.ReloadLevel();     // calling the ReloadLevel method here which is present in another class
        Instantiate(destroyedVFX, transform.position, Quaternion.identity);     // through Instantiate we can spawn objects in our scene while the game is running
                                                                                // Declaration :
                                                                                // public static Object Instantiate(Object original, Vector3 position, Quaternion rotation);
                                                                                // Parameters :
                                                                                // original - an existing object that you want to make a copy of
                                                                                // position - position for the new object 
                                                                                // rotation - no rotation in this case

        Destroy(gameObject);        // this line of code means whenever the laser hits a gameobject which has this script attached to it, it will destroy itself
        
        // Debug.Log("Hit " + other.name);
        // Debug.Log($"Hit {other.gameObject.name}");
        // both code gives the name of the object to which we hit on Trigger 
    }
}
