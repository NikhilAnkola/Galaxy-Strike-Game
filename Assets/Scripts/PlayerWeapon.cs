using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] GameObject[] lasers;      // here we created an array of lasers to store multiple of them 
    [SerializeField] RectTransform crosshair;
    [SerializeField] Transform targetPoint;
    [SerializeField] float targetDistance = 100f;       // how far will we keep our target object so that our laser goes towards it 
    bool isFiring = false;

    void Start()
    {
        Cursor.visible = false;     // this will make our cursor invisible while shooting     
    }

    void Update()
    {
        ProcessFiring();
        MoveCrosshair();
        MoveTargetPoint();
        AimLasers();
    }

    public void OnFire(InputValue value)
    {
        isFiring = value.isPressed;     // isPressed returns true if button is pressed and false if button is not pressed 
    }

    void ProcessFiring()
    {
        foreach (GameObject laser in lasers)        // foreach is used when we want each laser in the array lasers to execute the code written below 
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;     // in the laser GameObject we are accesing the ParticleSystem component and 
                                                                                    // then accesing emission from the ParticleSystem 
            emissionModule.enabled = isFiring;                                      // if true then emission enabled and if false emission not enabled 
        }
    }

    void MoveCrosshair()
    {
        crosshair.position = Input.mousePosition;   // in this line of code we'll assign our mouse's position to our crosshair's position 
    }

    void MoveTargetPoint()
    {
        Vector3 targetPointPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetDistance);
        targetPoint.position = Camera.main.ScreenToWorldPoint(targetPointPosition); // ScreenToWorldPoint takes 3 parameters 
                                                                                    // 1) x-position - where we have given our mouse's x-position
                                                                                    // 2) y-position - where we have given our mouse's y-position
                                                                                    // 3) some float distance - we have kept the sphere's distance from camera here 
                                                                                    // these parameters are stored in targetPointPosition and we are calling it here
                                                                                    // we are also accessing our main camera from Camera  
                                                                                    // basically when we move our crosshair this sphere will also move with it so that further we can tell our laser to go in the direction of sphere 
                                                                                    // ie. kinda go where the crosshair is pointing and this will make it look as if we are shooting where we point our crosshair  
    }

    void AimLasers()
    {
        foreach (GameObject laser in lasers)
        {
            Vector3 fireDirection = targetPoint.position - this.transform.position;     // this subtraction will not directly give the distance or direction between 
                                                                                        // them but a Vector3 value between them which we can use to calculate direction, distance, etc 
            Quaternion rotateToTarget = Quaternion.LookRotation(fireDirection);         // Quaternion.LookRotation requires 2 parameters
                                                                                            // i) Vector3 forward - the direction to look in
                                                                                            // ii) Vector3 upwards = Vector3.up - the vector that defines in which direction up is 
                                                                                        // we use our Vector3 value fireDirection to get the direction in which our laser should face/rotate to 
            laser.transform.rotation = rotateToTarget;                                  // this rotation is assigned to the laser's rotation 
        }
    }
}
