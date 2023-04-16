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

    }

    void Update()
    {
        sight = new Ray(transform.position, transform.forward);
        
    }


}
