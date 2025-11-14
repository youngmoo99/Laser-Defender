using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damage = 10; // 주는 피해량

    // 피해량 반환
    public int GetDamage()
    {
        return damage;
    }
  
    // 피격 시 자기 자신 파괴 (총알 제거 등)
    public void Hit()
    {
        Destroy(gameObject);
    }
   
}
