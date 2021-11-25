using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateManager : MonoBehaviour
{
   
    
    private void OnTriggerEnter(Collider other)
    {
        if ( other.gameObject.tag == "Player" )
        {
           
            if (other.gameObject.name == "Player_V0")
            {
                other.gameObject.name = "Player_V1";
                other.gameObject.transform.GetChild(4).GetChild(0).gameObject.SetActive(false);
                other.gameObject.transform.GetChild(4).GetChild(1).gameObject.SetActive(true);

            }
            else if  (other.gameObject.name == "Player_V1")
            {
                other.gameObject.name = "Player_V2";
                other.gameObject.transform.GetChild(4).GetChild(1).gameObject.SetActive(false);
                other.gameObject.transform.GetChild(4).GetChild(2).gameObject.SetActive(true);
            }
            else if (other.gameObject.name == "Player_V2")
            {
                other.gameObject.name = "Player_V3";
                other.gameObject.transform.GetChild(4).GetChild(2).gameObject.SetActive(false);
                other.gameObject.transform.GetChild(4).GetChild(3).gameObject.SetActive(true);
            }
        }
         if (other.gameObject.tag == "Friend")
          {

            if (other.gameObject.name == "F1V0")
            {
                other.gameObject.name = "F1V1";
                other.gameObject.transform.GetChild(4).GetChild(1).gameObject.SetActive(false);
                other.gameObject.transform.GetChild(4).GetChild(2).gameObject.SetActive(true);

            }
            else if (other.gameObject.name == "F1V1")
            {
                other.gameObject.name = "F1V2";
                other.gameObject.transform.GetChild(4).GetChild(2).gameObject.SetActive(false);
                other.gameObject.transform.GetChild(4).GetChild(3).gameObject.SetActive(true);
            }
            else if (other.gameObject.name == "F1V2")
            {
                other.gameObject.name = "F1V3";
                other.gameObject.transform.GetChild(4).GetChild(3).gameObject.SetActive(false);
                other.gameObject.transform.GetChild(4).GetChild(4).gameObject.SetActive(true);
            }
        }
    }
}
