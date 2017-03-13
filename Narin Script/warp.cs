using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class warp : MonoBehaviour
{

   


   

    // Use this for initialization
    void Start()
    {
        


    }

    // Update is called once per frame
    

        

        
        void OnTriggerEnter(Collider player)
    {
            if (player.tag == "Player")
            {
            SceneManager.LoadScene("scene");
        }
        }
    }

