using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 3.0f;

    public float obstacleRange = 5.0f;

    public float timerDuration = 10;
    public bool timerIsRunning = true;

    [SerializeField] EnemySight eyes;

    private void Awake()
    {
        eyes = GetComponentInParent<EnemySight>();
    }

    public void Wander(float setDuration)
    {
        timerDuration -= Time.deltaTime;

        if (timerDuration > 5)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
            AvoidWalls();
        }
        else if(timerDuration <= 0)
        {
            timerDuration = setDuration;
        }
    }

    void AvoidWalls()
    {
        if (eyes.areSeeing)
        {
            if (eyes.hit.distance < obstacleRange)
            {
                float angle = Random.Range(-90, 90);
                transform.Rotate(0, angle, 0);
            }
        }
    }
}
