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
    public Animator anim;
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



    void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }
}