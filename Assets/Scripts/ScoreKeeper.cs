using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int score; // 현재 점수
    static ScoreKeeper instance; // 싱글톤

    void Awake()
    {
        ScoreKeeperSingleton();
    }

    // 싱글톤 패턴 (씬 전환 시 유지)
    void ScoreKeeperSingleton()
    {
        if(instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // 현재 점수 반환
    public int GetScore()
    {
        return score;
    }

    // 점수 추가 (음수면 감소 기능)
    public void ModifyScore(int value)
    {
        score += value;
        Mathf.Clamp(score, 0, int.MaxValue); // 0 아래로 내려가지 않게 제한
        Debug.Log(score);
    }

    // 점수 초기화 (게임 재시작 시 호출)
    public void ResetScore()
    {
        score = 0;
    }

}
