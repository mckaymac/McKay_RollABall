using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;
    public SphereCollider col;
    public LayerMask groundLayers;
    

    private Rigidbody rb;
    private int count;
    private float jump = 4.0f;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<SphereCollider>();
        count = 0;
        SetCountText();
        winText.text = "";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //moves the ball 
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

        //checks to see if the ball is on the ground and if true then the ball can jump
        if(IsGrounded() && Input.GetKeyDown(KeyCode.Space)){
            //onGround = false; 
            rb.AddForce(Vector3.up*jump, ForceMode.Impulse); 
            
        }
    }

    private bool IsGrounded(){
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y,
         col.bounds.center.z), col.radius*0.9f, groundLayers);

    }


    void OnTriggerEnter(Collider other){

        if(other.gameObject.CompareTag("PickUp")){
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }

        if(other.gameObject.CompareTag("Booster")){
            rb.velocity = rb.velocity * 2f;
        }

        if(other.gameObject.CompareTag("Obstacle") || (transform.position.y < -5.0f)){
            transform.position = new Vector3(0,0.5f,0);
        }
    }

    void SetCountText(){
        countText.text = "Count: " + count.ToString();
        if(count >= 36){
            winText.text = "You Win!";
        }
    }
}
