using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySight : MonoBehaviour
{
    public Ray sight;
    public RaycastHit hit;
    public bool areSeeing;
    public GameObject seenObject = null;
    [SerializeField] float farSightAngle=90f, farSightDistance=100f, nearSightAngle=110f, nearSightDistance=20f;

    Vector3 playerPos, enemyVec;

    private void Awake()
    {
        EyeSight();
    }

    void Update()
    {
        //EyeSight();
    }

    public void EyeSight()
    {
        sight = new Ray(transform.position, transform.forward);

        areSeeing = Physics.SphereCast(sight, 0.75f, out hit);

        //if (areSeeing == false) ;
            //Debug.Log(seenObject);
            //seenObject = hit.transform.gameObject;
        
    }

    public bool IntruderSearch(GameObject target)
    {
        if(target != null) { 

            //grab the gameObject's transform
            Vector3 startVec = transform.position;
            //grab the gameObject's transform, but also add 1 to z
            Vector3 startVecFwd = transform.forward;

            RaycastHit hit;
            //Calculate the vector of the target in relation to the gameObject's Vector, instead of the world space
            //You can think of it as making a Vector3 of the target's position that is in Relative space, with
            //the gameObject's position as the origin point.
            Vector3 targetVec = target.transform.position - startVec;
            bool seenObject = Physics.Raycast(startVec, targetVec, out hit, farSightDistance);
            float seenObjectAngle = Vector3.Angle(targetVec, startVecFwd);
            float seenObjectDistance = Vector3.Distance(startVec, target.transform.position);

            if (seenObject && hit.collider.gameObject == target)
            {
                //If the Angle between the targetVector and the gameObject's forward Vector is less than the gameObject's
                //close vision cone, AND the Distance between the gameObject's position and the target's position is less than
                //or equal to the distance of the gameObject's near sight (peripheral vision), then return true.
                if ((seenObjectAngle < nearSightAngle &&
                    (seenObjectDistance <= nearSightDistance)))
                {
                    return true;
                }
                //If the Angle between the targetVector and the gameObject's forward Vector is less than the gameObject's
                //far vision cone, AND the Raycast hits within the far vision distance, then check to see if the hit is
                //is the target, if it is, return true, if not, then false.
                if ((seenObjectAngle) < farSightAngle && seenObject)
                {
                    // Debug.Log(hit.rigidbody.gameObject.name);
                    if (hit.collider.gameObject == target)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                return false;
            }
            return false;
        }
        return false;
    }
}
