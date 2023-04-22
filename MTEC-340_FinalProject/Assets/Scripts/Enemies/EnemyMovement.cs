using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 3.0f;

    public float obstacleRange = 5.0f;

    public Transform PatrolRoute;
    public List<Transform> Locations;
    private int _locationIndex = 0;
    private NavMeshAgent _agent;
    private float waitAtLocation;

    public float timerDuration = 10;
    public bool timerIsRunning = true;

    [SerializeField] EnemySight eyes;

    private void Awake()
    {
        eyes = GetComponentInParent<EnemySight>();
    }

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        InitializePatrolRoute();
        MoveToNextPatrolLocation();
    }

    public void Patrol()
    {
        if (_agent.remainingDistance < 0.2f && !_agent.pathPending)
        {
                MoveToNextPatrolLocation();
        }
    }

    void InitializePatrolRoute()
    {
        foreach(Transform child in PatrolRoute)
        {
            Locations.Add(child);
        }
    }

    void MoveToNextPatrolLocation()
    {
        if (waitAtLocation > 0f)
        {
            waitAtLocation -= Time.deltaTime;
        }
        else
        {
            if (Locations.Count == 0)
                return;
            _agent.destination = Locations[_locationIndex].position;
            _locationIndex = (_locationIndex + 1) % Locations.Count;
            waitAtLocation = 10f;
        }
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
