using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]

public class FPSInput : MonoBehaviour
{
    public float speed = 6.0f;
    public float gravity = -9.8f;
    public bool isCrouched = false;
    public InputAction playerControls;

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    private CharacterController _charControl;
    private Vector3 newMovement;

    [SerializeField] float charHeightCur=2f, charHeightTarget, charCenterY, charSpeedTarget;

    public float target;

    private void Start()
    {
        _charControl = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //PlayerMovement();
    }


    public void PlayerMovement()
    {
        newMovement = playerControls.ReadValue<Vector3>();

        //float deltaX = Input.GetAxis("Horizontal") * speed;
        //float deltaZ = Input.GetAxis("Vertical") * speed;

        float deltaX = newMovement.x * speed;
        float deltaZ = newMovement.z * speed;

        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);
        movement.y = gravity;

        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _charControl.Move(movement);

        PlayerCrouch();
    }

    public void PlayerCrouch()
    {
        if(isCrouched == false)
        {
            //charHeightTarget = 1 + Input.GetAxis("Crouch") * 0.75f;
            if (newMovement.y <= 0)
            {
                charHeightTarget = 1 + newMovement.y * 0.75f;

                //speed = Mathf.MoveTowards(speed, 2 * charSpeedTarget, speed * Time.deltaTime);

                charHeightCur = Mathf.MoveTowards(charHeightCur, 2 * charHeightTarget, speed * Time.deltaTime);
                _charControl.height = charHeightCur;

                charCenterY = 0.5f - charHeightCur / 2;
                _charControl.center = new Vector3(0, charCenterY, 0);

                if (charHeightCur == 0.5)
                {
                    isCrouched = true;
                }
            }
        }
        else if(isCrouched && Physics.Raycast(transform.position, transform.up, 2) == false)
        {

            isCrouched = false;

        }

        if (newMovement.y <= 0)
        {
            charSpeedTarget = 6 + newMovement.y * 3;
            speed = Mathf.MoveTowards(speed, charSpeedTarget, 3 * Time.deltaTime);

            speed = Mathf.MoveTowards(speed, charSpeedTarget, 3 * Time.deltaTime);
        }
            //charSpeedTarget = 6 + Input.GetAxis("Crouch") * 3;

    }
}
