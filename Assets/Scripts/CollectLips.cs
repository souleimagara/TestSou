using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectLips : MonoBehaviour
{
    public Transform Player;
    float mSpeed = 10.0f;
    bool _folloowit;
    Vector3 DistancefromTarget;
     static int minDistance;
    public Animator anim;

   

    private void FixedUpdate()
    {
        DistancefromTarget = transform.position - Player.position;
    }
    void LateUpdate()
    {
        if (_folloowit)
        {
            Follow();
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if ( other.gameObject.tag == "Player")
        {
            minDistance = PlayerPrefs.GetInt("distance") + 2;
            PlayerPrefs.SetInt("distance", minDistance);
            PlayerPrefs.Save();
            Debug.Log("Fuck it");
            _folloowit = true;
        }
    }
    void Follow()
    {
        transform.LookAt(Player);
        
        if (DistancefromTarget.magnitude > minDistance)
        {
            anim.SetTrigger("Run");
            transform.Translate(0.0f, 0.0f, mSpeed * Time.deltaTime);
           
        }
    }
}
