using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class DepthOfFieldControl : MonoBehaviour
{
    [SerializeField] PostProcessProfile _mainProfile;
    DepthOfField _depthOfField2;
    [SerializeField] float delta = 300f;
    Vector3 point;
    Ray focusRay;
    private Camera _camera;
    private void Awake()
    {

    }
    void Start()
    {
        _camera = GetComponent<Camera>();
        _depthOfField2 = _mainProfile.GetSetting<DepthOfField>();
        _depthOfField2.focalLength.value = 120f;
        _depthOfField2.aperture.value = 11f;
    }

    void Update()
    {
        Ray cameraFocus = CameraLookAt();

        float focusDistance = _depthOfField2.focusDistance.value;

        RaycastHit hit;
        if(Physics.Raycast(cameraFocus, out hit, Mathf.Infinity))
        {
            float hitDistance = Vector3.Distance(Camera.main.transform.position, hit.point);

            //_depthOfField2.focusDistance.value = hitDistance;

            //delta *= Time.deltaTime;

            Debug.Log("delta: " + delta);
            Debug.Log("fixedDeltaTime: " + Time.fixedDeltaTime);
            Debug.Log("deltaTime: " + Time.deltaTime);

            focusDistance = (Mathf.Lerp(focusDistance, hitDistance, delta * Time.deltaTime));
            Debug.Log(focusDistance);
            _depthOfField2.focusDistance.value = focusDistance;
            //_depthOfField2.focalLength.value = (Mathf.MoveTowards(_depthOfField2.focalLength.value, hitDistance*.125f, delta ));
        }

    }

    private Ray CameraLookAt()
    {
        Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);

        Ray ray = _camera.ScreenPointToRay(point);

        return ray;
    }
}
