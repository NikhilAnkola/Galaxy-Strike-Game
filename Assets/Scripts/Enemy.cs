using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject destroyedVFX;
    [SerializeField] int hitPoints = 3;
    [SerializeField] int scoreValue = 10;
    ScoreBoard scoreboard;

    void Start()
    {
        scoreboard = FindFirstObjectByType<ScoreBoard>();       // this will find the first object of the type 'ScoreBoard' and then stop searching 
                                                                // the ScoreBoard class of another script is stored in scoreboard 
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();   // this method will give our enemies some sort of health bar so they don't destroy on the first hit 
    }

    public void ProcessHit()
    {
        hitPoints--;

        if (hitPoints <= 0)
        {
            scoreboard.IncreaseScore(scoreValue);     // classname.methodname()
                                                      // scoreValue is the argument for IncreaseScore parameter 
                                                      
            Instantiate(destroyedVFX, transform.position, Quaternion.identity);     // through Instantiate we can spawn objects in our scene while the game is running
                                                                                    // Declaration :
                                                                                    // public static Object Instantiate(Object original, Vector3 position, Quaternion rotation);
                                                                                    // Parameters :
                                                                                    // original - an existing object that you want to make a copy of
                                                                                    // position - position for the new object 
                                                                                    // rotation - no rotation in this case

            Destroy(gameObject);        // this line of code means whenever the laser hits a gameobject which has this script attached to it, it will destroy itself 
        }
    }
}
