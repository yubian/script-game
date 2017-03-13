using UnityEngine;
using System.Collections;

public class DestoryEnemy : MonoBehaviour {
    void OnTriggerEnter(Collider en)
    {
        if (en.tag == "Checkinsportlight")
        {
            Destroy(gameObject);
        }
    }
}
