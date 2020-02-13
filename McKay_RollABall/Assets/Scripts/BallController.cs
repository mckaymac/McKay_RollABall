using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;
    public Vector3 jump;
    public float jumpHeight = 2.0f;

    private Rigidbody rb;
    private int count;
    private bool onGround;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
        onGround = true;
        jump = new Vector3(0.0f, 2.0f, 0.0f);
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
        if(onGround == true && Input.GetKeyDown(KeyCode.Space)){
            rb.AddForce(jump * jumpHeight, ForceMode.Impulse);
            onGround = false; 
            
        }
    }

    void OnCollisionStay()
         {
             onGround = true;
         }



    void OnTriggerEnter(Collider other){

        if(other.gameObject.CompareTag("PickUp")){
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }

        if(other.gameObject.CompareTag("Booster")){
            rb.velocity = rb.velocity * 6f;
        }
    }

    void SetCountText(){
        countText.text = "Count: " + count.ToString();
        if(count >= 13){
            winText.text = "You Win!";
        }
    }
}
