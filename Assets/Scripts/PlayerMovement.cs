using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private bool playState;
    public GameObject prefab;
    public static int offset1 = 2;
    public GameObject Player;

    [SerializeField] private Joystick joystick;
    [SerializeField] private float sideForce;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float minX, maxX;
    [SerializeField] private GameObject Camera;
    [SerializeField] private GameObject winPanel, losePanel;

   
    //Camera
    public Transform target;
    public  float offsetZ = -3;

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
           
            GameObject SpawnedStandMini = Instantiate(prefab, new Vector3(transform.position.x, transform.position.y, transform.position.z) + (Vector3.forward * offset1), transform.rotation) as GameObject;
            SpawnedStandMini.name = "F1V0";
            SpawnedStandMini.GetComponent<Animator>().SetTrigger("Run");
            SpawnedStandMini.transform.SetParent(this.gameObject.transform);
            offset1 = offset1 + 2;
        }
        else if (other.gameObject.tag == "Wall")
        {
            if ( this.gameObject.transform.childCount == 1)
            {
                rb.AddForce(Vector3.back * 50000.0f);
                Player.gameObject.name = "Player_V0";
                Player.transform.GetChild(4).GetChild(0).gameObject.SetActive(true);
                Player.transform.GetChild(4).GetChild(1).gameObject.SetActive(false);
                Player.transform.GetChild(4).GetChild(2).gameObject.SetActive(false);
                Player.transform.GetChild(4).GetChild(3).gameObject.SetActive(false);

            }
           
        }
    }

}