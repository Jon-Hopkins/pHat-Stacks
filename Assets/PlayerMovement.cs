using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public GameObject Cube;

    public float playerWalkingSpeed = 5f;
    public float playerRunningSpeed = 15f;
    public float jumpStrength = 4f;
    public float verticalRotationLimit = 80f;

    float forwardMovement;
    float sidwaysMovement;
    float verticalVelocity;

    public static float height;
    public static float heightHat = 0;//        height of all hats on player

   

    float verticalRotation = 0f;

    CharacterController cc;
    public static Vector3 myPosition;



    // Use this for initialization
    void Awake()
    {
        cc = GetComponent<CharacterController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        height = GetComponent<MeshRenderer>().bounds.size.y;
        //Debug.Log(height);

    }

    // Update is called once per frame
    void Update()
    {

        myPosition = transform.position;
        

        float horizontalRotation = Input.GetAxis("Mouse X");
        transform.Rotate(0, horizontalRotation, 0);

        verticalRotation -= Input.GetAxis("Mouse Y");
        verticalRotation = Mathf.Clamp(verticalRotation, -verticalRotationLimit, verticalRotationLimit);// Mathf.Clamp(what you want to limit, minimum, maximum)
        //Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

        forwardMovement = Input.GetAxis("Vertical") * playerWalkingSpeed;
        sidwaysMovement = Input.GetAxis("Horizontal") * playerWalkingSpeed;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            forwardMovement = Input.GetAxis("Vertical") * playerRunningSpeed;
            sidwaysMovement = Input.GetAxis("Horizontal") * playerRunningSpeed;
        }
        if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                //DynamicCrosshairs.spread = DynamicCrosshairs.RUN_SPREAD;
            }
            else
            {
                //DynamicCrosshairs.spread = DynamicCrosshairs.WALK_SPREAD;
            }
        }
        if (cc.isGrounded == false)
        {
            //DynamicCrosshairs.spread = DynamicCrosshairs.JUMP_SPREAD;
        }


        verticalVelocity += Physics.gravity.y * Time.deltaTime;

        if (Input.GetButton("Jump") && cc.isGrounded)
        {
            verticalVelocity = jumpStrength;
        }

        Vector3 playerMovement = new Vector3(sidwaysMovement, verticalVelocity, forwardMovement);

        cc.Move(transform.rotation * playerMovement * Time.deltaTime);
    }

    
}
