using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    //PlayerStateMachine Player;
    public enum RotationAxes
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }

    private Vector3 playerLook;

    public InputAction playerLean;

    public bool canLean=true;

    public RotationAxes axes = RotationAxes.MouseXAndY;

    public float sensitivityHor = 1f;
    public float sensitivityVert = 0.5f;

    public float minimumVert = -45.0f;
    public float maximumVert = 45.0f;

    private float _rotationX = 0;

    //[SerializeField] float _rotationZ;

    public Transform _Pivot;

    [SerializeField] float speed=100f, maxLeanAngle=20f;

    float curAngle = 0f;

    private bool paused;

    private void OnEnable()
    {
        playerLean.Enable();
    }

    private void OnDisable()
    {
        playerLean.Disable();
    }

    private void Awake()
    {

        if (_Pivot == null && transform.parent != null) _Pivot = transform.parent;
    }

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
            rb.freezeRotation = true;
    }

    void Update()
    {
        Look();

    }

    public void Look()
    {
        playerLook = playerLean.ReadValue<Vector3>();

        if (Time.timeScale != 0f)
        {
            if (axes == RotationAxes.MouseX)
            {
                //transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
                transform.Rotate(0, playerLook.x * sensitivityHor * 0.1f, 0);
            }
            else if (axes == RotationAxes.MouseY)
            {
                //_rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
                _rotationX -= playerLook.y * sensitivityVert * 0.1f;
                _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);

                float rotationY = transform.localEulerAngles.y;

                transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
                if (canLean)
                    Peek();
            }
            else
            {
                //_rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
                _rotationX -= playerLook.y;
                _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);

                //float delta = Input.GetAxis("Mouse X") * sensitivityHor;
                float delta = playerLook.x;
                float rotationY = transform.localEulerAngles.y + delta;

                transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);

                if (canLean)
                    Peek();
            }
        }
    }

    public void Peek()
    {
        RaycastHit hit;

        //if(Physics.Raycast(ray, out hit, 100))
        if (Physics.Raycast(transform.up, transform.right, out hit, 0.2f) == false )
        {
        //Debug.Log(hit);
        //Debug.Log(hit.point);
            //Debug.DrawRay(transform.up, transform.right, Color.white, 0.2f);
        //curAngle = Mathf.MoveTowardsAngle(curAngle, maxLeanAngle * Input.GetAxis("Lean"), speed * Time.deltaTime);
          curAngle = Mathf.MoveTowardsAngle(curAngle, -maxLeanAngle * playerLook.z, speed * Time.deltaTime);
        _Pivot.transform.localRotation = Quaternion.AngleAxis(curAngle, Vector3.forward);
        }
    }

    
    public void AdjustMouseSensX(float sens)
    {
        sensitivityHor = sens;
    }

    public void AdjustMouseSensY(float sens)
    {
        sensitivityVert = sens;
    }
}
