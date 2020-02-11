using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;
    public float jumpHeight;

    private Rigidbody rb;
    private int count;
    private Boolean onGround;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
        onGround = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

        if(onGround.equals(true) && Input.GetKeyDown(KeyCode.Space)){
            Jump();
        }
    }

    void Jump(){
        
    }



    void OnTriggerEnter(Collider other){

        if(other.gameObject.CompareTag("PickUp")){
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    void SetCountText(){
        countText.text = "Count: " + count.ToString();
        if(count >= 13){
            winText.text = "You Win!";
        }
    }
}
