using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{   
    EnemySpawner enemySpawner;
    WaveConfigSO waveConfig;
    List<Transform> waypoints;
    int waypointIndex = 0;

    void Awake()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }
    void Start()
    {   
        waveConfig = enemySpawner.GetCurrentWave();
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[waypointIndex].position;    
    }

 
    void Update()
    {
        FollowPath();
    }

    void FollowPath()
    {
        if(waypointIndex < waypoints.Count)
        {
            Vector3 targetPosition = waypoints[waypointIndex].position; // 이동할 목표 위치 지정
            float delta = waveConfig.GetMoveSpeed() * Time.deltaTime; // 속도 계산
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta); // 현재 위치에서 delta만큼 이동 
            if(transform.position == targetPosition) // 목표 위치에 도달하면
            {
                waypointIndex++; // 다음위치로 이동 준비
            }
        }
        else 
        {
            Destroy(gameObject); // 모든웨이포인트를 지난경우 오브젝트 삭제
        }

    }
}
