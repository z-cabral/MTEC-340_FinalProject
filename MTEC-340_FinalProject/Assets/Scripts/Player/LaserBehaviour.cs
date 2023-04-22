using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehaviour : MonoBehaviour
{
    private Camera _camera;

    [SerializeField] Transform laser;
    private float cooldown = 0f;

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
        if (cooldown > 0f)
        {
            cooldown -= Time.deltaTime;
            //Debug.Log(cooldown);
        }
        else if (cooldown <= 0f)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                laser.gameObject.SetActive(true);

                Ray laserPoint = PlayerLookAt();

                RaycastHit hit;

                if (Physics.Raycast(laserPoint, out hit))
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
                    cooldown = 60f;
                }
            }          
        }

        if (Input.GetButtonUp("Fire1"))
        {
            laser.gameObject.SetActive(false);
        }

        if (Input.GetButtonDown("Interact"))
        {
            Ray playerLook = PlayerLookAt();

            RaycastHit hit;

            if (Physics.Raycast(playerLook, out hit))
            {
                if (hit.distance < 1)
                {
                    GameObject hitObject = hit.transform.gameObject;

                    if (hitObject.CompareTag("Consumeable"))
                    {
                        Consumeable item = hitObject.GetComponent<Consumeable>();

                        Debug.Log(item);

                        switch (item.consumeable)
                        {
                            default:

                                break;
                            case ConsumeableType.InvisibilityCloak:
                                item.PickUp();

                                break;
                        }
                    }
                }
            }
        }
    }

    private Ray PlayerLookAt()
    {
        Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);

        Ray ray = _camera.ScreenPointToRay(point);

        return ray;
    }

    private IEnumerator SphereIndicator(Vector3 pos)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;
        yield return new WaitForSeconds(1);
        Destroy(sphere);
    }

}
