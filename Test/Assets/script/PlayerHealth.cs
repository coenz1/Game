using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth: MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    public GameObject deadEffect;
    private int HealAmount = 25;


    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void HurtPlayer(int damageToGive)
    {
        currentHealth -= damageToGive;


        if (currentHealth <= 0)
        {
            //aud_src.PlayOneShot(dead_sound); 
            DeadEffect();
            Destroy(gameObject);
            SceneManager.LoadScene("Menu");
        }
    }

    private void DeadEffect()
    {
        if (deadEffect != null)
        {
            GameObject effect = Instantiate(deadEffect, transform.position, Quaternion.identity);
            Destroy(effect, 2f);
        }
    }
    
    public void Heal(int HealAmount)
    {
        currentHealth += HealAmount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Heart")
        {
            Heal(HealAmount);
            other.gameObject.SetActive(false);
        }
    }

}
