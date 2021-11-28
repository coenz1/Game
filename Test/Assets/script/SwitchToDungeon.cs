using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchToDungeon : MonoBehaviour
{
    public string sceneLoad;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !collision.isTrigger)
        {
            SceneManager.LoadScene(sceneLoad);
        }
    }

}
