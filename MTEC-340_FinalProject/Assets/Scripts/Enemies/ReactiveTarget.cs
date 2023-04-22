using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    
    public bool deactivated=false;

    public void ReactToHit(GuardStateMachine guard)
    {
        guard.IsPowered = false;

        if(deactivated == true)
        {
            StartCoroutine(Deactivate());
        }
    }

    public void ReactToHit(CameraStateMachine cctv)
    {
        cctv.IsPowered = false;

        if (deactivated == true)
        {
            StartCoroutine(Deactivate());
        }
    }

    private IEnumerator Deactivate()
    {
        this.transform.Rotate(-75, 0, 0);

        yield return new WaitForSeconds(10f);
        this.transform.Rotate(75, 0, 0);
        deactivated = false;
    }
}
