using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehaviour : MonoBehaviour
{
    private Camera _camera;

    void Start()
    {
        _camera = GetComponent<Camera>();        
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);

            Ray ray = _camera.ScreenPointToRay(point);

            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                Debug.Log("Hit " + hit.point);
            }
        }
    }

}
