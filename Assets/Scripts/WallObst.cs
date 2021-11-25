using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallObst : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if ( other.gameObject.tag == "Friend")
        {
            Destroy(other.gameObject);
        }
       
    }
}
