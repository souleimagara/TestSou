using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderBoard : MonoBehaviour
{
    public GameObject Panel;
    public GameObject Player;
   
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            Player.SetActive(false);
            Panel.SetActive(true);
        }
    }
}
