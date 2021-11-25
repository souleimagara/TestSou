using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private bool playState;
    public Transform Friend;
    public GameObject prefab;
    int offset1 = 2;

    [SerializeField] private Joystick joystick;
    [SerializeField] private float sideForce;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float minX, maxX;
    [SerializeField] private GameObject Camera;
    [SerializeField] private GameObject winPanel, losePanel;

    List<Transform> unityGameObjects = new List<Transform>();
    //Camera
    public Transform target;
    public float offsetZ = -3;

    public float smoothX;
    public Camera cam;

    private void Start()
    {
      
        rb = GetComponent<Rigidbody>();
        playState = true;

      //  transform.DOScaleY(0, 8);
    }

    private void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), transform.position.y, transform.position.z);
        if (playState == true)
        {
            rb.velocity = new Vector3(joystick.Horizontal * sideForce, rb.velocity.y, moveSpeed);
           
        }

       
    }

    private void LateUpdate()
    {
        cam.transform.position = new Vector3
           (Mathf.Lerp(cam.transform.position.x, target.transform.position.x, smoothX * Time.deltaTime), cam.transform.position.y, target.transform.position.z + offsetZ);
    }

    private void OnTriggerEnter(Collider other)
    {
        if ( other.gameObject.tag == "Friend")
        {
           
            //other.GetComponent<Animator>().SetTrigger("Run");
            Destroy(other.gameObject);
            //other.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + x  );
            GameObject SpawnedStandMini = Instantiate(prefab, new Vector3(transform.position.x, transform.position.y, transform.position.z) + (Vector3.forward * offset1), transform.rotation) as GameObject;
            SpawnedStandMini.name = "F1V0";
            SpawnedStandMini.GetComponent<Animator>().SetTrigger("Run");
            SpawnedStandMini.transform.SetParent(Friend);
            offset1 = offset1 + 2;
        }
    }

}