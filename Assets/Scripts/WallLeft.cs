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
            count = count + 1;
            if (count <= 3)
            {
                ImageLeft[count].SetActive(true);
                count = 0;
            }
            explosion.Play();
            Transform snake = other.transform.parent;
            LipsMovment snakeComponent = snake.GetComponent<LipsMovment>();
            snakeComponent.remmovepart(other.gameObject);
            Destroy(other.gameObject);
            StartCoroutine(waiteforfewsecond());
        }
        if (other.gameObject.tag == "lipeHead")
        {
            count = count + 1;
            if (count <= 3)
            {
                ImageLeft[count].SetActive(true);
            }
            explosion.Play();
            other.transform.position += Vector3.back * 10;
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
