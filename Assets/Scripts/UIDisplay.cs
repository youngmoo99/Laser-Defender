using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{   
    [Header("Health")]
    [SerializeField] Slider healthSlider; // 체력 표시 슬라이더
    [SerializeField] Health playerHealth; // 플레이어의 Health 스크립트
    [Header("Score")]
    [SerializeField] TMP_Text scoreText;  // 점수 표시 텍스트
    ScoreKeeper scoreKeeper; // 점수 관리 스크립트 참조

    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    void Start()
    {   
        // 시작 시 최대 체력 슬라이더 값 설정
        healthSlider.maxValue = playerHealth.GetHealth();
    }

   
    void Update()
    {   
        // 체력 슬라이더 및 점수 텍스트 실시간 업데이트
        healthSlider.value = playerHealth.GetHealth();   
        scoreText.text = scoreKeeper.GetScore().ToString("000000000");   // 9자리 0패딩 표시
    }
}
