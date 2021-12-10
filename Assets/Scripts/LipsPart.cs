using UnityEngine;

public class LipsPart : MonoBehaviour
{
    private Vector3 previousPosition;
    private Quaternion previousRotation;

    public GameObject lips1;
    public GameObject lips2;
    public GameObject lips3;
    public GameObject lips4;

    public Animator anim;
    public RuntimeAnimatorController Friendanim;

    public GameObject Friends;
    public Rigidbody rb;
    public CapsuleCollider cp;

    bool right = false;
    bool left = false;
    
    public void Start()
    {
        name = this.gameObject.name;
    }
    public void UpdateTransform()
    {
        previousPosition = transform.position ;
        previousRotation = transform.rotation;

       

    }
   

    public Vector3 GetPreviousPosition()
    {
        return previousPosition ;
    }

    public Quaternion GetPreviousRotation()
    {
        return previousRotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if ( other.gameObject.tag == "Wall")
        {
            
            switch (this.gameObject.name)
            {
                case "Player_V0":
                    lips1.SetActive(false);
                    lips2.SetActive(true);
                    this.gameObject.name = "Player_V1";
                    break;
                case "Player_V1":
                    lips2.SetActive(false);
                    lips3.SetActive(true);
                    this.gameObject.name = "Player_V2";
                    break;
                case "Player_V2":
                    lips3.SetActive(false);
                    lips4.SetActive(true);
                    this.gameObject.name = "Player_V3";
                    break;
            }

           
        }
        if (other.gameObject.tag == "Enemy")
        {

           if (! (this.gameObject.tag == "lipeHead"))
           
          
           {
                this.gameObject.AddComponent<LipsEating>();
                cp.isTrigger = true;
               
               
                Transform  lip = this.transform.parent;
                LipsMovment lipcom = lip.GetComponent<LipsMovment>();
                lipcom.remmovepart(this.gameObject);

                randomposition();
                transform.tag = "Friend";
                
                anim.runtimeAnimatorController = Friendanim as RuntimeAnimatorController;
               
           }
           else
            {
                transform.position += Vector3.back * 10 ;

                Transform parent = this.transform.parent.gameObject.transform;
                foreach (Transform item in parent)
                {
                    if ( item.tag != "lipeHead")
                    {
                        randompositionitem(item);
                        parent.GetComponent<LipsMovment>().remmovepart(item.gameObject);
                        item.gameObject.AddComponent<LipsEating>();
                        item.GetComponent<CapsuleCollider>().isTrigger = true;
                    }
                }
            }
           
        }
        if ( other.gameObject.tag =="Finish")
        {
            Transform lip = this.transform.parent;
            LipsMovment lipcom = lip.GetComponent<LipsMovment>();
            lipcom.showLEaderBord();
        }
      
        
       
    }

  public  void randomposition()
    {
        int randomPick = Random.Range(1, 3);
        switch (randomPick)
        {
            case 1:
                right = true;
                break;
            case 2:
                left = true;
                break;
          
            default: break;


        }

        if (right)
        {
            transform.position += Vector3.right * Random.Range(0.5f, 0.7f);
            transform.position += Vector3.forward * Random.Range(0.5f, 5f);
        }
        if (left)
        {
            transform.position += Vector3.left * Random.Range(0.5f, 0.7f);
            transform.position += Vector3.forward * Random.Range(0.5f, 5f);

        }
       
   }
    public void randompositionitem( Transform item)
    {
        int randomPick = Random.Range(1, 3);
        switch (randomPick)
        {
            case 1:
                right = true;
                break;
            case 2:
                left = true;
                break;

            default: break;


        }

        if (right)
        {
            item.transform.position += Vector3.right * Random.Range(0.5f, 0.7f);
            item.transform.position += Vector3.forward * Random.Range(0.5f, 5f);
        }
        if (left)
        {
            item.transform.position += Vector3.left * Random.Range(0.5f, 0.7f);
            item.transform.position += Vector3.forward * Random.Range(0.5f, 5f);

        }

    }
}

