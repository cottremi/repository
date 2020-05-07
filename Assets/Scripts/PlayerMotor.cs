//FROM TUTORIAL: https://www.youtube.com/watch?v=Qf4x1h2Pw3Q&list=PLKklF7YNi0lOM0C8r_L3JN3oTC6AY9iFE&index=7

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
   	float moveSpeed = 4;
	float gravity = 6;

	Vector3 moveDirection;

 	CharacterController controller;

	void Start ()
	{
		controller = GetComponent<CharacterController> ();
	}

	void Update ()
	{
		Move ();
	}

	void Move()
	{
		float moveX = Input.GetAxis ("Horizontal");
		float moveZ = Input.GetAxis ("Vertical");

		if (controller.isGrounded) {
		moveDirection = new Vector3 (moveX, 0, moveZ);
		moveDirection *= moveSpeed;
		} 

		moveDirection.y -= gravity;
		controller.Move (moveDirection * Time.deltaTime);

	}
}
