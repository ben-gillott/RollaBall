using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

	public float speedMod;	
	public Text countText;
	public Text winText;
	public bool isGrounded;

    private Rigidbody rb;
    private int count;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == ("Ground") && isGrounded == false)
        {
            isGrounded = true;
        }

     }


    void Update(){
    	if (Input.GetKeyDown(KeyCode.Space) && isGrounded){
            rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
            isGrounded = false;
        }

        if(transform.position.y < -20){
        	rb.velocity = Vector3.zero;
    		rb.angularVelocity = Vector3.zero; 
        	transform.position = new Vector3 (0, 3, 0);

        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement*speedMod);

        //rb.AddRelativeForce(Vector3.forward * speedMod);

    }




    void OnTriggerEnter(Collider other){
    	if(other.gameObject.CompareTag("Pick Up")){
    		other.gameObject.SetActive(false);
    		count += 1;
    		SetCountText();
    	}
    }

    void SetCountText(){
    	countText.text = "Count: "+ count.ToString();

    	if(count >= 8){
    		winText.text = "おめでとう！";
    	}
    }
}
