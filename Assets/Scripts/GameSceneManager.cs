using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;      // using this namespace for reloading purposes 
public class GameSceneManager : MonoBehaviour
{
    public void ReloadLevel()   // this does the work of reloading the scene on crashing 
    {
        StartCoroutine(ReloadLevelRoutine());       // different way of calling Coroutines 
    }

    IEnumerator ReloadLevelRoutine()       // this is used to create a delay after crashing instead of directly reloading the scene 
    {
        yield return new WaitForSeconds(1f);        /* Syntax : IEnumerator NameofRoutine()         // function name should be ending with Routine
                                                                {
                                                                    yield return new WaitForSeconds(1f);
                                                                    do some other logic 
                                                                }
                                                    */

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;       // this gets the index of the current scene and stores it in the variable 
        SceneManager.LoadScene(currentSceneIndex);                              // using LoadScene() the scene with index number stored in currentSceneIndex is loaded 
    }
}
