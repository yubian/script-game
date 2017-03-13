using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

    public GameObject obj;
	// Use this for initialization
	void Start () {
        if (SceneManager.GetActiveScene().name == "Ending")
        {
            Invoke("delaygomenu", 5);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void goLevel1()
    {
        if (SceneManager.GetActiveScene().name == "Menu" || SceneManager.GetActiveScene().name == "FirstScene"||
             SceneManager.GetActiveScene().name == "GameOver")
        {
            obj.SetActive(true);
        }
        Invoke("delaygoscene", 5);

    }
    void delaygoscene()
    {
        SceneManager.LoadSceneAsync("Scene");
    }
    void delaygomenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void goMenu()
    {
        if (SceneManager.GetActiveScene().name == "Menu" || SceneManager.GetActiveScene().name == "FirstScene"
            ||
             SceneManager.GetActiveScene().name == "GameOver")
        {
            obj.SetActive(true);
        }
        SceneManager.LoadScene("Menu");

    }
    public void goCredit()
    {
        if (SceneManager.GetActiveScene().name == "Menu"|| SceneManager.GetActiveScene().name == "FirstScene")
        {
            obj.SetActive(true);
        }
        SceneManager.LoadScene("Credit");
    }
    public void goFirstscene()
    {
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            obj.SetActive(true);
        }
        Invoke("delaygoscene1", 5);

    }
    void delaygoscene1()
    {
        SceneManager.LoadSceneAsync("FirstScene");
    }
    public void goExit()
    {
        Application.Quit();
    }

    void OnTriggerEnter(Collider en)
    {
        if (en.tag == "Player")
        {
            goLevel1();
        }
    }
        }
