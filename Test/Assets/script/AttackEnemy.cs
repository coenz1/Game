using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemy : MonoBehaviour
{
    public int damageToGive = 2;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy" || other.tag == "Dummy")
        {
            HealthEnemy eHealthMan;
            eHealthMan = other.gameObject.GetComponent<HealthEnemy>();
            eHealthMan.HurtEnemy(damageToGive);

        }

    }
}
