using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteScroller : MonoBehaviour
{
    [SerializeField] Vector2 moveSpeed;

    Vector2 offset;
    Material material;

    void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    void Update()
    {
        offset += moveSpeed * Time.deltaTime; // 매 프레임마다 moveSpeed 만큼 offset 누적 
        material.mainTextureOffset = offset; // material의 텍스처 오프셋 값을 바꿔서 스크롤처럼 보이게함 
    }
}
