using UnityEngine;

using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private bool playState;


    [SerializeField] private Joystick joystick;
    [SerializeField] private float sideForce;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float minX, maxX;
    [SerializeField] private GameObject Camera;
    [SerializeField] private GameObject winPanel, losePanel;


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
            other.GetComponent<Animator>().SetTrigger("Run");
            other.transform.SetParent(this.gameObject.transform);
            other.transform.position = new Vector3(transform.position.x, other.gameObject.transform.position.y, other.gameObject.transform.position.z);
        }
    }

}