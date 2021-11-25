using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallObst : MonoBehaviour
{
    
    public GameObject[] ImageRight;
    private void OnTriggerEnter(Collider other)
    {
        if ( other.gameObject.tag == "Friend")
        {
            
            Destroy(other.gameObject);
            PlayerMovement.offset1 = PlayerMovement.offset1 - 2;
        }
       
    }
}
