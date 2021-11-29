using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    private void Start()
    {
		StartCoroutine(ButtonDelay());
	}
    public void PlayGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
	}

	IEnumerator ButtonDelay()
	{
		yield return new WaitForSeconds(10);
	}

	public void QuitGame()
	{
		Debug.Log("quit");
		Application.Quit();
	}
}
