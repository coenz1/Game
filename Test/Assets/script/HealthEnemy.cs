using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEnemy : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    public GameObject deadEffect;

    private Animator anim;

    private SpriteRenderer enemySprite;
    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        enemySprite = GetComponent<SpriteRenderer>(); 
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HurtEnemy(int damageToGive)
    {
        currentHealth -= damageToGive;

        if (currentHealth <= 0)
        {
            isDead = true;
            DeadEffect();
            Destroy(gameObject);
        }
    }

    private void DeadEffect()
    {
        if(deadEffect != null)
        {
            GameObject effect = Instantiate(deadEffect, transform.position, Quaternion.identity);
            Destroy(effect, 2f);
        }
    }

}
