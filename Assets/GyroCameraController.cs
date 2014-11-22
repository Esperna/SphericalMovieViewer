using UnityEngine;
using System.Collections;

public class GyroCameraController : MonoBehaviour {

	void Update () 
	{
		Quaternion gyro = Input.gyro.attitude;
		this.transform.localRotation = Quaternion.Euler (90, 0, 0) * (new Quaternion (-gyro.x, -gyro.y, gyro.z, gyro.w));

		const float dive_trigger_down_thresh = -0.05f;
		const float dive_trigger_up_thresh = 0.07f;
		Debug.Log (Input.acceleration.x);

		if (Input.acceleration.x < dive_trigger_down_thresh) {
			GameObject.Find("Sherer100").GetComponent<textureRenew>().divingStatus = DivingStatus.GoingDown;
		} else {
			GameObject.Find("Sherer100").GetComponent<textureRenew>().divingStatus = DivingStatus.GoingUp;
		}
	}
}
