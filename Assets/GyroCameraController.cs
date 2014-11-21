using UnityEngine;
using System.Collections;

public class GyroCameraController : MonoBehaviour {
	
	private GameObject gui_text;

	void Start()
	{
		const int destroy_time = 3;
		gui_text = GameObject.Find("InitialText");
		Destroy (gui_text, destroy_time);
	}

	private bool is_diving_now = false;
	private float timer;
	private const int waitingTime = 30;

	void Update () 
	{
		Quaternion gyro = Input.gyro.attitude;
		this.transform.localRotation = Quaternion.Euler (90, 0, 0) * (new Quaternion (-gyro.x, -gyro.y, gyro.z, gyro.w));

		const float dive_trigger_thresh = -0.05f;
		Debug.Log (Input.acceleration.x);
		if (Input.acceleration.x < dive_trigger_thresh) {
			is_diving_now = true;
		} 
		else {

		}

		if(is_diving_now){
			timer += Time.deltaTime;
			if (timer > waitingTime) {
				is_diving_now = false;
				timer = 0;
				Debug.Log("END");
			}
		}
	}
	

}
