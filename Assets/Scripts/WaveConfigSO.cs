using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{   
    [SerializeField] List<GameObject> enemyPrefabs; // 이 웨이브에서 사용할 적 프리펩 리스트
    [SerializeField] Transform pathPrefab; // 적이 이동할 경로(Waypoint 부모)
    [SerializeField] float moveSpeed = 5f; // 이동 속도
    [SerializeField] float timeBetweenEnemySpawns = 1f; // 적 생성 간격
    [SerializeField] float spawnTimeVariance = 0f; // 생성 간격 랜덤 편차
    [SerializeField] float minimumSpawnTime = 0.2f; // 최소 생성 간격 제한

    // 첫 번째 웨이포인트 반환 (적 스폰 위치)
    public Transform GetStartingWaypoint()
    {
        return pathPrefab.GetChild(0);
    }

    // 전체 웨이포인트 리스트 반환
    public List<Transform> GetWaypoints()
    {
        List<Transform> waypoints = new List<Transform>();
        foreach (Transform child in pathPrefab)
        {
            waypoints.Add(child);
        }

        return waypoints;

    }

    // 이동속도 반환
    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    // 적 개수 반환
    public int GetEnemyCount()
    {
        return enemyPrefabs.Count;
    }

    // 지정 인덱스의 적 프리팹 반환
    public GameObject GetEnemyPrfabs(int index)
    {
        return enemyPrefabs[index];
    }

    // 적 생성 간격 랜덤 반환
    public float GetRandomSpawnTime()
    {
        float spawnTime = Random.Range(timeBetweenEnemySpawns - spawnTimeVariance,
                                        timeBetweenEnemySpawns + spawnTimeVariance);

        return Mathf.Clamp(spawnTime, minimumSpawnTime, float.MaxValue); // Clamp(값, 최소값, 최대값) 값 범위 제한
    }

}
