using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gems : MonoBehaviour
{
    public TextMeshProUGUI text;
    private int gems;
    // Start is called before the first frame update
    void Start()
    {
        gems = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Gem"))
        {
            gems += 1;
            Destroy(collision.gameObject);
            text.text = gems.ToString();
        }
    }

}
