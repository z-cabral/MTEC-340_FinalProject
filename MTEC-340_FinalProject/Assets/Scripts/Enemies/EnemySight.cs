using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySight : MonoBehaviour
{
    public Ray sight;
    public RaycastHit hit;
    public bool areSeeing;
    public GameObject seenObject=null;
    public float dotSight, viewRadius, viewAngle;

    //Vector3 target, enemyPos, heading, dot;

    private void Awake()
    {
        EyeSight();

        //FoV = this.GetComponentInChildren<Collider>();
    }

    void Update()
    {
        EyeSight();
        //target = GameBehavior.Instance.PlayerPos.position;
        //VisionCone(target);
    }

    public void EyeSight()
    {
        sight = new Ray(transform.position, transform.forward);

        areSeeing = Physics.SphereCast(sight, 0.75f, out hit);

        seenObject = hit.transform.gameObject;

    }

    public Vector3 DirFromAngle(float angleInDegrees)
    {
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }

    //public void VisionCone(Vector3 target)
    //{
    //    enemyPos = transform.position;

    //    heading = target.normalized - enemyPos.normalized;
    //    heading = heading.normalized;

    //    dotSight = Vector3.Dot(target, heading); 
}
