using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{   
    [SerializeField] float shakeDuration = 0.5f; // 카메라 흔들리는 시간
    [SerializeField] float shakeMagnitude = 0.5f; // 카메라 흔들림 강도
    Vector3 initialPosition; // 원래 카메라 위치
    void Start()
    {
        initialPosition = transform.position;

    }

    // 외부에서 호출하여 흔들림 실행
    public void Play()
    {
        StartCoroutine(Shake());
    }

    // 카메라 흔들림 코루틴
    IEnumerator Shake()
    {   
        float elapsedTime = 0f;
        while(elapsedTime < shakeDuration) 
        {   
            // 카메라를 무작위 방향으로 흔들기 (2d)
            transform.position = initialPosition + (Vector3)Random.insideUnitCircle * shakeMagnitude; 
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame(); // 한 프레임 기다리고 반복
        }

        // 흔들림이 끝나고 원래위치 되돌림 
        transform.position = initialPosition; 
    }
}
