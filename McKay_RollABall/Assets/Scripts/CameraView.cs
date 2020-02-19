using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraView : MonoBehaviour
{

    public GameObject Player;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        //Sets the distance between the player and the camera
        offset = transform.position - Player.transform.position;
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //The camera follows the the player
        transform.position = Player.transform.position + offset;
        
    }
}
