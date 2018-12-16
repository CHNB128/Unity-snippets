using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_CharacterController : MonoBehaviour {

  public float Speed = 6.0F;
  public float JumpForce = 8.0F;
  public float Gravity = 20.0F;
  public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
  public RotationAxes Axes = RotationAxes.MouseXAndY;
  public float RotateSensitivity = 1.5F;

  private CharacterController Controller;
  private float RotateAngleYMin = -60F;
  private float RotateAngleYMax = 60F;
  private Vector3 MoveDirection = Vector3.zero;
  private float RotationY = 0F;

  void Awake () {
    Controller = GetComponent<CharacterController> ();
  }

  void ProcessMovment () {
    if (Controller.isGrounded) {
      MoveDirection = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
      MoveDirection = transform.TransformDirection (MoveDirection);
      MoveDirection *= Speed;
      if (Input.GetButton ("Jump")) {
        MoveDirection.y = JumpForce;
      }
    }
    MoveDirection.y -= Gravity * Time.deltaTime;
    Controller.Move (MoveDirection * Time.deltaTime);
  }

  void CameraControl () {
    if (Axes == RotationAxes.MouseXAndY) {
      float rotationX =
        transform.localEulerAngles.y +
        Input.GetAxis ("Mouse X") *
        RotateSensitivity;
      RotationY += Input.GetAxis ("Mouse Y") * RotateSensitivity;
      RotationY = Mathf.Clamp (
        RotationY,
        RotateAngleYMin,
        RotateAngleYMax
      );
      transform.localEulerAngles = new Vector3 (-RotationY, rotationX, 0);
    } else if (Axes == RotationAxes.MouseX) {
      transform.Rotate (0, Input.GetAxis ("Mouse X") * RotateSensitivity, 0);
    } else {
      RotationY += Input.GetAxis ("Mouse Y") * RotateSensitivity;
      RotationY = Mathf.Clamp (RotationY, RotateAngleYMin, RotateAngleYMax);
      transform.localEulerAngles = new Vector3 (-RotationY, transform.localEulerAngles.y, 0);
    }
  }

  void FixedUpdate () {
    ProcessMovment ();
    CameraControl ();
  }
}