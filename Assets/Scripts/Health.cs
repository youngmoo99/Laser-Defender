using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Networking.Types;

public class Health : MonoBehaviour
{   
    [SerializeField] bool isPlayer; // 플레이어인지 적인지 구분
    [SerializeField] int health = 50; // 체력
    [SerializeField] int score = 50; // 적 처치 점수
    [SerializeField] ParticleSystem hitEffect; // 피격 이펙트
    [SerializeField] bool applyCameraShake; // 카메라 흔들기 여부
    CameraShake cameraShake;
    AudioPlayer audioPlayer;
    ScoreKeeper scoreKeeper;
    LevelManager levelManager;

    void Awake()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        levelManager = FindObjectOfType<LevelManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        if (damageDealer != null)
        {   
            TakeDamage(damageDealer.GetDamage()); // 체력 감소
            PlayHitEffect(); // 피격 파티클
            audioPlayer.PlayDamageClip(); // 피격 사운드
            ShakeCamera(); // 카메라 흔들기
            damageDealer.Hit(); // 총알 제거
        }
    }

    // 체력 감소 처리
    void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {    
            Die();          
        }
    }

    // 피격 시 파티클 생성 후 일정 시간 뒤 파괴
    void PlayHitEffect()
    {
        if(hitEffect != null)
        {
            ParticleSystem instance = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }

    // 카메라 흔들림 실행
    void ShakeCamera()
    {
        if(cameraShake != null && applyCameraShake)
        {
            cameraShake.Play();
        }
    }

    // 체력 확인용 Getter
    public int GetHealth()
    {
        return health;
    }

    // 체력 0 일때 사망 처리
    void Die()
    {   
        if(!isPlayer)
        {   
            // 적 사망 시 점수 증가
            scoreKeeper.ModifyScore(score);
        }
        else 
        {   
            // 플레이어 사망 시 게임오버
            levelManager.LoadGameOver();
        }
        Destroy(gameObject); 
    }

}
