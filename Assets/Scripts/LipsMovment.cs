using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class LipsMovment : MonoBehaviour
{
    public float speed;
    private float currentSpeed;

    public GameObject partPrefab0;
    public GameObject partPrefab1;
    public GameObject partPrefab2;
    public GameObject partPrefab3;
    public GameObject HeadPrefab;

    private float distanceBetween;
    private List<Transform> partslips;

    private float nailTransformTimer;
    private Camera currentCamera;
    private float cameraToHeadDistance;

    Transform part;


    public GameObject LeaderBord;
    public RuntimeAnimatorController Friendanim;
    bool stopmvmt;
    void Start()
    {
        currentSpeed = speed;
        distanceBetween = partPrefab0.transform.localScale.z ;
        partslips = new List<Transform>();
        nailTransformTimer = distanceBetween;
        currentCamera = Camera.main;

   

        Transform head = Instantiate(partPrefab0, transform).transform;
        head.gameObject.tag = "lipeHead";
        head.name = "Player_V0";
        GameObject coneged =   Instantiate(HeadPrefab, head.transform.position - (head.transform.forward), head.transform.rotation);
        coneged.transform.SetParent(head.transform);
        partslips.Add(head);

        cameraToHeadDistance = Vector3.Distance(currentCamera.transform.position, head.position);

      
       
       
    }

    void FixedUpdate()
    {
        if(stopmvmt == false)
        {
          
            Move();
        }

        UpdateNailTransforms();

    }

    public void AddPart( string name)
    {
       
        int count = partslips.Count;

        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, partslips.Count * -distanceBetween);
        spawnPosition += new Vector3(spawnPosition.x, spawnPosition.y, spawnPosition.z);
       
            switch (name)
            {
                case "Friends":
                    part = Instantiate(partPrefab0, spawnPosition, Quaternion.identity, transform).transform;
                    part.name = "Player_V0";
                part.tag = "Friend";
                partslips.Add(part.transform);

                partslips[count - 1].GetComponent<Animator>().Play("grow");
                    break;

                case "Player_V0":
                    part = Instantiate(partPrefab0, spawnPosition, Quaternion.identity, transform).transform;
                    part.name = "Player_V0";
                part.tag = "Friend";
                partslips.Add(part.transform);

                partslips[count - 1].GetComponent<Animator>().Play("grow");
                    break;
                case "Player_V1":
                    part = Instantiate(partPrefab1, spawnPosition, Quaternion.identity, transform).transform;
                    part.name = "Player_V1";
                part.tag = "Friend";
                partslips.Add(part.transform);

                partslips[count - 1].GetComponent<Animator>().Play("grow");
                    break;
                case "Player_V2":
                    part = Instantiate(partPrefab2, spawnPosition, Quaternion.identity, transform).transform;
                    part.name = "Player_V2";
                part.tag = "Friend";
                partslips.Add(part.transform);

                partslips[count - 1].GetComponent<Animator>().Play("grow");
                    break;
            case "Player_V3":
                part = Instantiate(partPrefab3, spawnPosition, Quaternion.identity, transform).transform;
                part.name = "Player_V3";
                part.tag = "Friend";
                partslips.Add(part.transform);

                partslips[count - 1].GetComponent<Animator>().Play("grow");
                break;

            }
      
       
       

       
      

        
    }
    public void remmovepart(GameObject item)
    {
        partslips.Remove(item.transform);
    }
 
    void UpdateNailTransforms()
    {
        nailTransformTimer += Time.deltaTime ;
       
        if (nailTransformTimer  >= distanceBetween   / (currentSpeed + float.Epsilon))
        {
           
                for (int i = 0; i < partslips.Count; i++)
                {

                partslips[i].GetComponent<LipsPart>().UpdateTransform();




                }

                nailTransformTimer = 0.0f;
           
           
        }
    }

    void Move()
    {


        //if (Input.GetMouseButton(0))
        //{
        Vector3 lookAtVector = partslips[0].position + Vector3.forward;



        Vector3 screenPosition = Input.mousePosition;
            screenPosition.z = cameraToHeadDistance;

            Vector3 worldPosition = currentCamera.ScreenToWorldPoint(screenPosition);

            lookAtVector.x = Mathf.Clamp(worldPosition.x, -1.45f, 1.45f);


        partslips[0].LookAt(lookAtVector);
        partslips[0].Translate(new Vector3(0.0f, 0.0f, currentSpeed * Time.deltaTime));

            // Move snake tail

            if (partslips.Count > 1)
            {

                for (int i = 1; i < partslips.Count; i++)
                {

                    LipsPart partComponent = partslips[i - 1].GetComponent<LipsPart>();
                partslips[i].position = partComponent.GetPreviousPosition();
                partslips[i].rotation = partComponent.GetPreviousRotation();
                }
            }
        //}
      
    }

  
  

    public void showLEaderBord()
    {
        for (int i = 0; i < partslips.Count; i++)
        {
            partslips[i].GetComponent<Animator>().runtimeAnimatorController = Friendanim as RuntimeAnimatorController;
           
        }
        stopmvmt = true;
        LeaderBord.SetActive(true);
    }


  
}

