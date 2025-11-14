using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip; // 총알 발사 사운드
    [SerializeField] [Range(0f, 1f)] float shootingVolume = 1f; // 발사음 볼륨

    [Header("Damage")]
    [SerializeField] AudioClip damageClip; // 피격 사운드
    [SerializeField ] [Range(0f, 1f)] float damageVolume = 1f; // 피격음 볼륨

    static AudioPlayer instance; // 싱글톤 인스턴스 (배경음 중복 방지)


    void Awake()
    {
        ManageSingleton();
    }

    // 씬이 바뀌어도 오브젝트 유지하고 중복 방지
    void ManageSingleton()
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

    // 발사 사운드 재생
    public void PlayShootingClip()
    {
        PlayClip(shootingClip, shootingVolume);
    }

    
    // 피격 사운드 재생
    public void PlayDamageClip()
    {
        PlayClip(damageClip, damageVolume);
    }

    // 오디오 클립을 지정된 볼륨으로 카메라 위치에서 재생
    void PlayClip(AudioClip clip, float volume)
    {
        if(damageClip != null)
        {   
            Vector3 cameraPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip,cameraPos,volume);
        }
    }

}
