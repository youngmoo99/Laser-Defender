using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{   
    [SerializeField] List<WaveConfigSO> waveConfigs; // 스폰할 웨이브 설정 리스트
    [SerializeField] float timeBetweenWaves = 0f; // 웨이브 간격
    [SerializeField] bool islooping; // 무한 반복 여부
    WaveConfigSO currentWave; // 현재 웨이브 데이터 참조
    void Start()
    {
        StartCoroutine(SpawnEnemyWaves());
    }

    // 현재 웨이브 정보 반환 (적 이동 경로 참고용)
    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }

    // 적 스폰 루프
    IEnumerator SpawnEnemyWaves()
    {   
        do
        {
            foreach(WaveConfigSO wave in waveConfigs)
            {
                currentWave = wave;
                for(int i = 0; i < currentWave.GetEnemyCount(); i++) 
                {   
                    // 적 프리팹 생성 (시작 위치, 회전값, 부모)
                    Instantiate(currentWave.GetEnemyPrfabs(0), 
                                currentWave.GetStartingWaypoint().position, 
                                Quaternion.Euler(0,0,180),
                                transform);
                    
                    // 적 개체 간 스폰 텀
                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }

                // 웨이브 간 텀
                yield return new WaitForSeconds(timeBetweenWaves);
            }
        }
        while(islooping);

  
    }
}
