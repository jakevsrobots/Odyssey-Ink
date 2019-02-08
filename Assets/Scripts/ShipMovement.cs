// Just a super basic boat movement script.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour {
  public float speed = 4f;
  public float runSpeed = 8f;
  public float turnSpeed = 40f;
  public Camera followCamera;

  Vector3 cameraDistance; 
  CharacterController controller; 

  void Awake() {
    controller = GetComponent<CharacterController>();

    // Remember the camera's relationship to the ship based on how they are
    // positioned in the editor. 
    
    cameraDistance = transform.position - followCamera.transform.position;
  }

  void Update() {
    float _speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : speed;

    transform.Rotate(0, Input.GetAxis("Horizontal") * Time.deltaTime * turnSpeed, 0);
    controller.Move(transform.forward * Input.GetAxis("Vertical") * Time.deltaTime * _speed); 

    followCamera.transform.position = transform.position - cameraDistance;
	}
}
