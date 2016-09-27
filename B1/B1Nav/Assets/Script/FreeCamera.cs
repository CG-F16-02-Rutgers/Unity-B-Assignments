using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class FreeCamera : MonoBehaviour {


    //moveHorizontal = Input.GetAxis("Horizontal");
    //moveVertical = Input.GetAxis("Vertical");

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
     Vector3 offset = new Vector3 (0.0f,0.0f,0.0f);
     float moveHorizontal = 0;
     float moveVertical = 0;
     moveHorizontal = Input.GetAxis("Horizontal");
     moveVertical = Input.GetAxis("Vertical");

            if (Input.GetKey(KeyCode.Space) && transform.position.y <100)
            {
                offset = new Vector3(moveHorizontal * 0.5f, 0.5f, 0.5f * moveVertical);
            }
            else if (transform.position.y > 1 && Input.GetKey(KeyCode.LeftShift))
            {
                offset = new Vector3(moveHorizontal * 0.5f, -0.5f, 0.5f * moveVertical);
            }
            else
            {
                offset = new Vector3(moveHorizontal * 0.5f, 0.0f, 0.5f * moveVertical);
            }
        transform.position = transform.position + offset;

    }
}

