using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightController : MonoBehaviour {

	public Light Target;
	private float buffer = 0f;

	void Update () {
		if (Input.GetKeyDown (KeyCode.F)) {
			if (buffer == 0) {
				buffer = Target.intensity;
				Target.intensity = 0;
			} else {
				Target.intensity = buffer;
				buffer = 0;
			}
		}
	}
}