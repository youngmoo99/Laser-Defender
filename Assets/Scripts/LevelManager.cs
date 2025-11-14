using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class LevelManager : MonoBehaviour
{   
    [SerializeField] float sceneLoadDelay = 2f; // 씬 전환 대기 기산
    ScoreKeeper scoreKeeper; // 점수 관리 스크립트 참조
    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    
    // 게임 씬 로드(점수 초기화 포함)
    public void LoadGame()
    {
        scoreKeeper.ResetScore();
        SceneManager.LoadScene("Game");
    }

    // 메인 메뉴로 이동
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // 게임 오버 씬으로 이동(지연 포함)
    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad("GameOver", sceneLoadDelay));

    }

    // 게임 종료
    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }

    // 지정한 시간 후 특정 씬 로드
    IEnumerator WaitAndLoad(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}