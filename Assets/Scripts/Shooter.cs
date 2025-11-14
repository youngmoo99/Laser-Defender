using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shooter : MonoBehaviour
{   
    [Header("General")]
    [SerializeField] GameObject projectilePrefab; // 발사체 프리팹
    [SerializeField] float projectileSpeed = 10f; // 총알 속도
    [SerializeField] float projectileLifetime = 5f; // 총알 수명
    [SerializeField] float baseFiringRate = 0.5f; // 기본 발사 간격

    [Header("AI")]
    [SerializeField] bool useAI; // AI(적) 자동 발사 여부
    [SerializeField] float firingRateVariance = 0f; // 발사 간격 랜덤 오차
    [SerializeField] float minimumFiringRate = 0.1f; // 최소 발사 속도

    [HideInInspector] public bool isFiring; // 플레이어 입력 또는 AI 발사 여부

    Coroutine firingCoroutine;
    AudioPlayer audioPlayer;

    void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }
    void Start()
    {
        if(useAI)
        {
            isFiring = true; // 적 자동 발사 시작
        }
    }
    void Update()
    {
        Fire();
    }

    // 발사 상태 제어 (입력에 따라 코루틴 시작/정지)
    void Fire()
    {   
        if(isFiring && firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FireContinuously()); 
        }
        else if(!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    // 총알을 일정 간격으로 계속 발사하는 루틴
    IEnumerator FireContinuously()
    {       
        
        while(true)
        {   
            // 총알 생성 및 이동 방향 지정
            GameObject instance = Instantiate(projectilePrefab, transform.position, Quaternion.identity); // Instantiate(오브젝트를, 내위치에, 기본회전) 복제
            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            
            if (rb != null)
            {
                rb.velocity = transform.up * projectileSpeed;
            }

            // 일정 시간이 지나면 총알 파괴
            Destroy(instance,projectileLifetime); 

            // 발사 간격 랜덤 조정
            float timeToNextProjectile = Random.Range(baseFiringRate - firingRateVariance,
                                                      baseFiringRate + firingRateVariance);
            timeToNextProjectile = Mathf.Clamp(timeToNextProjectile, minimumFiringRate, float.MaxValue);

            // 발사 사운드 재생
            audioPlayer.PlayShootingClip();

            // 다음 발사까지 대기
            yield return new WaitForSeconds(timeToNextProjectile);
        }
      
    }
}
