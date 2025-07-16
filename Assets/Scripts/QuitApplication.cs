using UnityEngine;
using UnityEngine.InputSystem;

public class QuitApplication : MonoBehaviour
{
    void Update()
    {
        RespondToDebugKeys(); 
    }

    void RespondToDebugKeys()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Debug.Log("You have successfully exited the game!!");
            Application.Quit();         // this line of code allows the player to exit the game or application by pressing the escape key 
        }
    }
}
