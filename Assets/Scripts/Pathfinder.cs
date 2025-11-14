using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{   
    EnemySpawner enemySpawner; // 현재 웨이브 정보 접근용
    WaveConfigSO waveConfig; // 웨이브 데이터(적 프리팹, 속도 등)
    List<Transform> waypoints; // 적 이동 경로
    int waypointIndex = 0; // 현재 목표 웨이포인트 인덱스

    void Awake()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }
    void Start()
    {   
        // 현재 웨이브의 이동 경로 불러오기
        waveConfig = enemySpawner.GetCurrentWave();
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[waypointIndex].position;    
    }

    void Update()
    {
        FollowPath();
    }

    // 적이 웨이포인트를 순서대로 이동하도록 제어
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
