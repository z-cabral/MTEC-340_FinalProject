using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public enum RotationAxes
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }

    public RotationAxes axes = RotationAxes.MouseXAndY;

    public float sensitivityHor = 9.0f;
    public float sensitivityVert = 9.0f;

    public float minimumVert = -45.0f;
    public float maximumVert = 45.0f;

    private float _rotationX = 0;

    //[SerializeField] float _rotationZ;

    public Transform _Pivot;

    [SerializeField] float speed=100f, maxLeanAngle=20f;

    float curAngle = 0f;

    private bool paused;

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
        if (Input.GetKeyDown(KeyCode.P))
        {
            paused = !paused;
        }

        if (paused == false)
        {
            if (axes == RotationAxes.MouseX)
            {
                transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
            }
            else if (axes == RotationAxes.MouseY)
            {
                _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
                _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);

                float rotationY = transform.localEulerAngles.y;

                transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);

                curAngle = Mathf.MoveTowardsAngle(curAngle, maxLeanAngle * Input.GetAxis("Lean"), speed * Time.deltaTime);
                _Pivot.transform.localRotation = Quaternion.AngleAxis(curAngle, Vector3.forward);

            }
            else
            {
                _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
                _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);

                float delta = Input.GetAxis("Mouse X") * sensitivityHor;
                float rotationY = transform.localEulerAngles.y + delta;

                transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);

                curAngle = Mathf.MoveTowardsAngle(curAngle, maxLeanAngle * -Input.GetAxis("Lean"), speed * Time.deltaTime);
                _Pivot.transform.localRotation = Quaternion.AngleAxis(curAngle, Vector3.forward);

            }
        }

        //_rotationZ = Mathf.LerpAngle(30, -30, Input.GetAxis("Lean") + .5f);



    }
}
