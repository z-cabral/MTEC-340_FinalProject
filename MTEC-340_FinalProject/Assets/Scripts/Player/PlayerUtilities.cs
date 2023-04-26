using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUtilities : MonoBehaviour
{
    public Ray up, left, right;

    PlayerStateMachine Player;

    private void Awake()
    {
        Player = GetComponent<PlayerStateMachine>();
    }

    public void Update()
    {
        up.origin = transform.position;
        right.origin = transform.position;
        left.origin = transform.position;

        up.direction = transform.up;
        right.direction = transform.right;
        left.direction = -transform.right;
    }
    private void SetPosition(Vector3 position)
    {
        this.transform.position = position;
    }

    private void SetRotation(Quaternion rotation)
    {
        this.transform.rotation = rotation;
    }

    private void SetScale(Vector3 scale)
    {
        this.transform.localScale = scale;
    }

    public void SetTransform(Vector3 pos, Quaternion rot, Vector3 sca)
    {
        SetPosition(pos);
        SetRotation(rot);
        SetScale(sca);
    }

    public void SetTransform(Vector3 pos, Quaternion rot)
    {
        SetPosition(pos);
        SetRotation(rot);
    }

    public void SetTransform(Vector3 pos, Vector3 sca)
    {
        SetPosition(pos);
        SetScale(sca);
    }

    public void SetTransform(Quaternion rot, Vector3 sca)
    {
        SetRotation(rot);
        SetScale(sca);
    }

}
