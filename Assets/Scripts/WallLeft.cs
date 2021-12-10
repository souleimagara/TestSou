using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallLeft : MonoBehaviour
{
    public GameObject[] ImageLeft;
    public ParticleSystem explosion;
    float currentMovementTime = 0f;
    int count = 0;
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;

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
            //other.transform.position += (Vector3.back * 500) * Time.deltaTime;



            //Vector3 targetPosition = other.transform.TransformPoint(new Vector3(0, 0, -5));
            //other.transform.position = Vector3.SmoothDamp(other.transform.position, targetPosition, ref velocity, smoothTime);

            float offset = -5f; //how much to move forward
            other.transform.DOMove(other.transform.position + other.transform.forward * offset, 1f);


            //currentMovementTime += Time.deltaTime;
            //Vector3 spawnPosition = new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z -5f);
            //other.transform.localPosition = Vector3.Lerp(other.transform.position, spawnPosition, currentMovementTime / 5f);
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
