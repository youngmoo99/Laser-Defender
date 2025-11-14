using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIGameOver : MonoBehaviour
{   
    [SerializeField] TextMeshProUGUI scoreText; // 점수 출력용 Text
    ScoreKeeper scoreKeeper; // scoreKeeper 참조

    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    void Start()
    {   
        // 게임 오버 시 점수 표시
        scoreText.text = "You Scored:\n" + scoreKeeper.GetScore();
    }
}
