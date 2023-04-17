using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySight : MonoBehaviour
{
    public Ray sight;
    public RaycastHit hit;
    public bool areSeeing;
    public GameObject seenObject=null;

    //[SerializeField] EnemyType _enemyType = EnemyType.guard;

    private void Awake()
    {
        EyeSight();
    }

    void Update()
    {
        EyeSight();
    }

    public void EyeSight()
    {
        sight = new Ray(transform.position, transform.forward);

        areSeeing = Physics.SphereCast(sight, 0.75f, out hit);

        seenObject = hit.transform.gameObject;
    }
}
