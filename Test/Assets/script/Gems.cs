using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gems : MonoBehaviour
{
    public TextMeshProUGUI text;
    private int gems;
	private bool a=false;
    // Start is called before the first frame update
    void Start()
    {
        gems = 0;
    }
	private GameObject currentTeleport;
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.E))
		{
			if(gems==4)
			{
				if(currentTeleport!=null)
				{
					transform.position=currentTeleport.GetComponent<Teleporter>().GetDestination().position;
					gems=0;
					text.text=gems.ToString();
				}
			}
		}
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
		if(collision.CompareTag("Door"))
		{
			currentTeleport=collision.gameObject;
		}
    }

		private void OnTriggerExit2D(Collider2D coll)
	{
		if(coll.CompareTag("Door"))
		{
			if(coll.gameObject==currentTeleport)
			{
				currentTeleport=null;
			}
		}
	}

}
