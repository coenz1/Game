using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    public GameObject deadEffect;
    //public static AudioClip dead_sound;
    //static AudioSource aud_src;


    private Animator anim;

    private SpriteRenderer enemySprite;
    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        enemySprite = GetComponent<SpriteRenderer>();
        //dead_sound = Resources.Load<AudioClip>("dead"); 
        //aud_src = GetComponent<AudioSource>(); 

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
}
