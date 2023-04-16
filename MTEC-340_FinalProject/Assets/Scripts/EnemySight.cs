using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySight : MonoBehaviour
{
    public Ray sight;

    [SerializeField] float rotateLimit, angle;

    [SerializeField] EnemyType _enemyType = EnemyType.guard;

    private bool inCoroutine=false;

    private void Start()
    {
        //StartCoroutine(Scan());
    }

    void Update()
    {
        sight = new Ray(transform.position, transform.forward);
        
    }

//    private IEnumerator Scan()
//    {
//            transform.Rotate(0, angle , 0);
//        yield return new WaitUntil(angle <= 45);
//        for (int angle = 0; angle >= -45; angle -= 1)
//            transform.Rotate(0, angle, 0);
//        yield return new Wai

//    }
}
