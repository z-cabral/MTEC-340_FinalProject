using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 3.0f;

    public float obstacleRange = 5.0f;

    [SerializeField] EnemySight eyes;

    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);

        RaycastHit hit;
        if (Physics.SphereCast(eyes.sight, 0.75f, out hit))
        {
            if (hit.distance < obstacleRange)
            {
                float angle = Random.Range(-110, 110);
                transform.Rotate(0, angle, 0);
            }
        }
    }
}
