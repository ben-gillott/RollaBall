using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

	public Transform player;
    public Rigidbody rb;
    public float smoothness = .125f;
	public Vector3 offset;



    // Start is called before the first frame update
    void Start()
    {
     	// offset = transform.position - player.transform.position; 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 desPos = player.position + offset;
        Vector3 smoothPos = Vector3.Lerp (transform.position, desPos, smoothness);

        transform.position = smoothPos;

        // transform.forward = rb.velocity;
        // transform.LookAt(player);
        //transform.position = player.transform.position + offset;
    }
}
