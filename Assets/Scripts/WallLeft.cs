using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallLeft : MonoBehaviour
{
    public GameObject[] ImageLeft;
    public ParticleSystem explosion;
    int count = 0; 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Friend")
        {
            count = count + 1 ;
            if ( count <= 3 )
            {
                ImageLeft[count].SetActive(true);
            }
            explosion.Play();
            Destroy(other.gameObject);
            PlayerMovement.offset1 = PlayerMovement.offset1 - 2;
            StartCoroutine(waiteforfewsecond());
        }

        IEnumerator waiteforfewsecond()
        {
            yield return new WaitForSeconds(1.5f);
            foreach (var item in ImageLeft)
            {
                item.SetActive(false);
            }
        }
    }
}
