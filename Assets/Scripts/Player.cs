using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{   
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] float paddingLeft; 
    [SerializeField] float paddingRight;
    [SerializeField] float paddingTop;
    [SerializeField] float paddingBottom;
    Vector2 rawInput;
    Vector2 minBounds; 
    Vector2 maxBounds;

    Shooter shooter;

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
    void OnMove(InputValue value) //플레이어 조작
    {
        rawInput = value.Get<Vector2>();
    }

    void OnFire(InputValue value) //플레이어 발사 
    {
        if(shooter != null)
        {
            shooter.isFiring = value.isPressed;
        }
    }

    void InitBounds() 
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0,0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1,1));
    }

    
}
