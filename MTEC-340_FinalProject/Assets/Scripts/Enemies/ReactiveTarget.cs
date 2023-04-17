using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{


    public void ReactToHit()
    {
        StartCoroutine(Deactivate());
    }

    private IEnumerator Deactivate()
    {
        this.transform.Rotate(-75, 0, 0);

        yield return new WaitForSeconds(1.5f);
        this.transform.Rotate(75, 0, 0);
    }
}
