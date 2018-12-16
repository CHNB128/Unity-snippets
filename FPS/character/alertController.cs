using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alertController : MonoBehaviour {

	float duration = 1.0f;

	private Light light;

	Color color0 = new Color(1f, 0.0f, 0.0f, 1f);
	Color color1 = new Color(0.2f, 0.0f, 0.0f, 1f);

	// Use this for initialization
	void Start () {
		light = GetComponent<Light> ();
	}

	// Update is called once per frame
	void Update () {
		float t = Mathf.PingPong(Time.time, duration) / duration;
		light.color = Color.Lerp(color0, color1, t);
	}
}
