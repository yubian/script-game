using UnityEngine;
using System.Collections;
public class GhostWalkmoveimg : MonoBehaviour {
    public GameObject enemy;
    GameObject tempgameobject;
    public GhostWalk ghos;
    // Use this for initialization
    // Update is called once per frame
    void Update()
    {
        transform.position = enemy.GetComponent<Transform>().position;
        if (ghos.getseeplayer() == true)
        {
            tempgameobject = ghos.getplay();
        }
        else
        {
            if (ghos.gettarget1() == true)
            {
                tempgameobject = ghos.getgame1();
            }
            else if (ghos.gettarget2() == true)
            {
                tempgameobject = ghos.getgame2();
            }
            else if (ghos.gettarget3() == true)
            {
                tempgameobject = ghos.getgame3();
            }
        }
        if (tempgameobject.GetComponent<Transform>().position.x > transform.position.x)
        {
            GetComponent<Transform>().localScale = new Vector3(0.2f, 0.2f, 1);
        }
        if (tempgameobject.GetComponent<Transform>().position.x < transform.position.x)
        {
            GetComponent<Transform>().localScale = new Vector3(-0.2f, 0.2f, 1);
        }
    }
}
