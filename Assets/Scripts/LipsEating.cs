using UnityEngine;
using UnityEngine.SceneManagement;

public class LipsEating : MonoBehaviour
{
   

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CollisionCone")
        {
            Transform lip = other.transform.parent.parent;
            LipsMovment lipcom = lip.GetComponent<LipsMovment>();
            lipcom.AddPart( this.gameObject.name);
            Destroy(gameObject);
        }
       
    }
}

