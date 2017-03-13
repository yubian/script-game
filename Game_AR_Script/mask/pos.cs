using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pos : MonoBehaviour {
    public int idpos;
    bool checkin = false;
    // bool frist = false;

    void Update()
    {
        if (checkin == true)
        {

        }
    }
   void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.tag == "itemmask")
        {
          //  if (frist == false)
          //  {
          //      obj.GetComponent<selectmask>().idpos = idpos;
           //     obj.GetComponent<selectmask>().targetid=idpos;
          //      frist = true;
          //  }
           // if(obj.GetComponent<selectmask>().targetid==idpos)
          //  {
                obj.GetComponent<selectmask>().idpos = idpos;
            //checkin = true;
           // }
           // Debug.Log("check");
        }
    }
        void OnTriggerExit(Collider obj)
    {
        if (obj.gameObject.tag == "itemmask")
        {
           // checkin = false;
            //obj.GetComponent<selectmask>().idpos = 0;
        }
    }

}
