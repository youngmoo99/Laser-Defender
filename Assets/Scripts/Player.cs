using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{   
    [SerializeField] float moveSpeed = 3f; // 이동 속도
    [SerializeField] float paddingLeft;  // 화면 왼쪽 경계 여백
    [SerializeField] float paddingRight; // 화면 오른쪽 경계 여백
    [SerializeField] float paddingTop; // 위쪽 여백
    [SerializeField] float paddingBottom; // 아래쪽 여백
    Vector2 rawInput; // 입력값
    Vector2 minBounds; 
    Vector2 maxBounds; 

    Shooter shooter; // 슈팅 스크립트 참조

    void Awake()
    {
        shooter = GetComponent<Shooter>();
    }
    void Start()
    {
        InitBounds();
    } 
    void Update()
    {
      PlayerMove();
    }

    void PlayerMove() // 플레이어 이동
    {
        Vector2 delta = rawInput * moveSpeed * Time.deltaTime;
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + paddingLeft, maxBounds.x - paddingRight); // Clamp 지정된 범위를 넘지 않게 막아주는 함수
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y + paddingBottom, maxBounds.y - paddingTop);
        transform.position = newPos;
    }

    // Input System - 이동 입력
    void OnMove(InputValue value) 
    {
        rawInput = value.Get<Vector2>();
    }

    // Input System - 발사 입력
    void OnFire(InputValue value)
    {
        if (shooter != null)
        {
            shooter.isFiring = value.isPressed;
        }
    }
    
    // 카메라 뷰 기준으로 이동 경계 계산
    void InitBounds() 
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0,0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1,1));
    }

    
}
