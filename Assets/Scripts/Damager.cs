using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    [SerializeField]
    float damageToOther = 2f, damageToSelf = 1f;

    [SerializeField]
    bool selfDamage = false;
    
    private Damageable damageable;

    void Awake(){
        damageable = GetComponent<Damageable>();
    }
    public void Damage(Damageable objectToDamage){
        int damageDirection = 0;
        if (transform.position.x > objectToDamage.transform.position.x) damageDirection = -1;
        else damageDirection = 1;
        objectToDamage.GetDamaged(damageToOther, damageDirection);
        if (selfDamage && damageable != null){
            damageable.GetDamaged(damageToSelf, -damageDirection);
        }
    }


}
