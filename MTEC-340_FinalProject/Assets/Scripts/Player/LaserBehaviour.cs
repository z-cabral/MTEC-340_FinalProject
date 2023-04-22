using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehaviour : MonoBehaviour
{
    private Camera _camera;

    [SerializeField] Transform laser;

    void Start()
    {
        _camera = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        laser = GetComponentInChildren<Transform>().transform.GetComponentInChildren<Light>().transform;
        laser.gameObject.SetActive(false);
    }

    private void OnGUI()
    {
        int size = 12;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 4;

        GUI.Label(new Rect(posX, posY, size, size), "*");
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);

            Ray laserRay = _camera.ScreenPointToRay(point);

            laser.gameObject.SetActive(true);

            RaycastHit hit;
            if(Physics.Raycast(laserRay, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;

                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                if (target != null)
                {
                    if (hitObject.CompareTag("Guard"))
                    {
                        target.ReactToHit(hitObject.GetComponent<GuardStateMachine>());
                    }
                    else if (hitObject.CompareTag("CCTV"))
                    {
                        target.ReactToHit(hitObject.GetComponent<CameraStateMachine>());
                    }
                    
                }
                else
                {
                    //StartCoroutine(SphereIndicator(hit.point));
                }
            }
        }
        if (Input.GetButtonUp("Fire1"))
        {
            laser.gameObject.SetActive(false);
        }
    }

    private IEnumerator SphereIndicator(Vector3 pos)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;
        yield return new WaitForSeconds(1);
        Destroy(sphere);
    }

}
