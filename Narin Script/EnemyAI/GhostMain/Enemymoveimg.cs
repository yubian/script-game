using UnityEngine;
using System.Collections;

public class Enemymoveimg : MonoBehaviour {
    public GameObject enemy;
    Transform player;
	// Use this for initialization
	void Start () {
        
	}
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
	// Update is called once per frame
	void Update () {
        transform.position = enemy.GetComponent<Transform>().position;
        if (player.position.x > transform.position.x)
        {
            GetComponent<Transform>().localScale = new Vector3(0.2f, 0.2f, 1);
        }
        if (player.position.x < transform.position.x)
        {
            GetComponent<Transform>().localScale = new Vector3(-0.2f, 0.2f, 1);
        }
    }
}
