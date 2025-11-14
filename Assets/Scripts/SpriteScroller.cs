using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteScroller : MonoBehaviour
{
    [SerializeField] Vector2 moveSpeed; // 배경 움직임 속도 (X,Y 방향)

    Vector2 offset; // 현재 텍스처 오프셋 값
    Material material; // 스프라이트의 머티리얼

    void Awake()
    {   
        // SpriteRenderer의 머티리얼을 가져와서 저장
        material = GetComponent<SpriteRenderer>().material;
    }

    void Update()
    {   
        offset += moveSpeed * Time.deltaTime; // 매 프레임마다 moveSpeed 만큼 offset 누적 
        material.mainTextureOffset = offset; // material의 텍스처 오프셋 값을 바꿔서 스크롤처럼 보이게함 
    }
}
