using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    void Start()
    {
        int numOfMusicPlayers = FindObjectsByType<MusicPlayer>(FindObjectsSortMode.None).Length;    // this variable will store the number of music players in our scene
                                                                                                    // FindObjectsSortMode.None means we dont want to sort the array of music players length 

        // this if statement means the first bg music that starts when we start our game will continue to play even after we crash
        // instead of starting the music again from start 
        // and this will destroy all other bg musics other than the first bg music 
        if (numOfMusicPlayers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }                                                                     
    }
}
