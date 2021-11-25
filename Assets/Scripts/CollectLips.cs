using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectLips : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if ( other.gameObject.tag == "Friend")
        {
            other.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        }
    }
}
