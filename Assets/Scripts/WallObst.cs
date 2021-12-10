using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallObst : MonoBehaviour
{
    
    public GameObject ImageRight;
    public GameObject particalsystem;
    private void OnTriggerEnter(Collider other)
    {
        if ( other.gameObject.tag == "Friend")
        {
            ImageRight.SetActive(true);
            particalsystem.SetActive(true);
            Transform lip = other.transform.parent;
            LipsMovment lipscom = lip.GetComponent<LipsMovment>();
            lipscom.remmovepart(other.gameObject);
            Destroy(other.gameObject);
         
        }
       
       
    }
}
