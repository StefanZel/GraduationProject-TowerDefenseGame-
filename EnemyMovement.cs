using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    
    private Transform target;
    private int wavepointIndex = 0;

    private Enemy enemy;

    public Transform partToRotate;
    public float turnSpeed = 10f;

    void Start()
    {
        enemy = GetComponent<Enemy>();

     
       target = Waypoints.points[0];

    
    }
     void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, enemy.speed * Time.deltaTime);
        Vector3 dir = target.position - transform.position;
        //transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World); - Used this to test a different method for moving. Works too
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNewWaypoint();
        }

        enemy.speed = enemy.startSpeed;
    }

    void GetNewWaypoint() 
    {
        if (wavepointIndex >= Waypoints.points.Length - 1) 
        {
            EndPath();
            return;
        
        }

        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    
    }

    void EndPath()
    {
        PlayerStats.Lives--;
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }
}

