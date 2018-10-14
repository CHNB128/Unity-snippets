using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

  public Transform bulletSpawn;
  public GameObject bulletPrefab;
  public float shootForce = 20.0f;

  // Use this for initialization
  void Start () {

  }

  // Update is called once per frame
  void Update () {
    if (Input.GetKeyDown(KeyCode.Space)) {
      var bullet = (GameObject)Instantiate (
        bulletPrefab,
        bulletSpawn.position,
        bulletSpawn.rotation
      );

      // Add velocity to the bullet
      bullet.GetComponent<Rigidbody>().velocity =
        new Vector3(1, 0.5f, 0) * shootForce;

      // Destroy the bullet after 2 seconds
      Destroy(bullet, 2.0f);
    }
  }
}
