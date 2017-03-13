using UnityEngine;
using System.Collections;

public class GhostMoveMain : MonoBehaviour {
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
    }
}
