using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{   
    [SerializeField] float shakeDuration = 0.5f; //흔들리는 시간
    [SerializeField] float shakeMagnitude = 0.5f; //흔들림 강도
    Vector3 initialPosition;
    void Start()
    {
        initialPosition = transform.position;

    }

    public void Play()
    {
        StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {   
        float elapsedTime = 0f;
        while(elapsedTime < shakeDuration) 
        {
            transform.position = initialPosition + (Vector3)Random.insideUnitCircle * shakeMagnitude; // 랜덤 좌표 반환
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame(); // 한 프레임 기다리고 반복
        }

        transform.position = initialPosition; // 흔들림이 끝나고 원래위치 되돌림 

    
    }

}
