using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float controlSpeed = 10f;      // this variable controls the speed of the player 
    [SerializeField] float xClampRange = 5f;
    [SerializeField] float yClampRange = 5f;
    [SerializeField] float controlRollFactor = 25f;
    [SerializeField] float controlPitchFactor = 25f;
    [SerializeField] float rotationSpeed = 15f;
    Vector2 movement;       // movement is used as a cache 

    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    public void OnMove(InputValue value)    // this method was created by unity when we created our Input Action Map named PlayerControls
                                            // which contained an Action named Move thus we get our method 'OnMove' 
    {
        movement = value.Get<Vector2>();    // this gets our Vector2 value 
    }

    void ProcessTranslation()
    {
        float xOffset = movement.x * controlSpeed * Time.deltaTime;     // if A is pressed movement.x = -1 and if D then movement.x = 1
                                                                        // Time.deltaTime used to achieve frame rate independency 
                                                                        // how much do we have to move left or right is stored in xOffset
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xClampRange, xClampRange);    // Mathf.Clamp() means we restrict the player's movement so it can't go off the screen
                                                                                // It takes three parameters : (float value, float min, float max)
                                                                                // float value = rawPos which is the postion of player on X-axis
                                                                                // float min = -xClampRange limit on negative X-axis
                                                                                // float max = xClampRange limit on positive X-axis

        float yOffset = movement.y * controlSpeed * Time.deltaTime;     // if W is pressed movement.y = 1 and if S then movement.y = -1
                                                                        // how much do we have to move up or down is stored in yOffset
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yClampRange, yClampRange);    // float value = rawYPos which is the position of player on Y-axis

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, 0f);       // transform.localPosition is the new position of the player
    }

    void ProcessRotation()
    {
        // Quaternion is way to encode rotations 
        float pitch = -controlPitchFactor * movement.y;  // -controlPitchFactor is multiplied with movement.y so that it not just rotates in one position but rotate along the Y-axis
        float roll = -controlRollFactor * movement.x;    // -controlRollFactor is multiplied with movement.x so that it not just rotates in one position but rotate along the X-axis

        Quaternion targetRotation = Quaternion.Euler(pitch, 0f, roll);   // transform.localRotation = Quaternion.Euler(x, y, z);
                                                                         // transform.localRotation = Quaternion.Euler(Pitch, Yaw, Roll);  

        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, rotationSpeed * Time.deltaTime); 
    }
}
