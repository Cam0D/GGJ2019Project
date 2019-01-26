using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 
public class dudeMove : MonoBehaviour {

	public GameObject Planet;
	public float speed;
	// private Vector3 endPosition = new Vector3(-6, -4, 0);

    void Start(){
    }

    void Update() 
    {
    	MoveAround();

  		// if(transform.position != endPosition) {
    //     	transform.position = Vector3.MoveTowards(transform.position, endPosition, speed * Time.deltaTime);
    //     }
    }

    void MoveAround()
    {

	if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) {
	 	transform.RotateAround(Planet.transform.position, Vector3.forward, speed * Time.deltaTime); //LEFT
		}
	if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) {
	 	transform.RotateAround(Planet.transform.position, Vector3.back, speed * Time.deltaTime); //RIGHT
		}

	}

    // rotationZ = Mathf.Clamp (rotationZ, -90, 90);
    // transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, -rotationZ);


	// float maxX = 4;
	// float maxY = 4;


	// Vector3 pos = transform.position;
	// pos.x = Mathf.Clamp (pos.x, -maxX, maxX);
	// pos.y = Mathf.Clamp (pos.y, -maxY, maxY);
	// transform.position = pos;

}
