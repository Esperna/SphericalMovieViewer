using UnityEngine;
using System.Collections;

public class GyroCameraController : MonoBehaviour {

	void Update () 
	{
		Quaternion gyro = Input.gyro.attitude;
		this.transform.localRotation = Quaternion.Euler (90, 0, 0) * (new Quaternion (-gyro.x, -gyro.y, gyro.z, gyro.w));

		const float dive_trigger_down_thresh = -0.2f;
		const float dive_trigger_up_thresh = 0.3f;

		Debug.Log ("x");
		Debug.Log (Input.acceleration.x);
	
		switch (GameObject.Find ("Sherer100").GetComponent<textureRenew> ().divingStatus) {
		case DivingStatus.FirstLoop:
			if (Input.acceleration.x < dive_trigger_down_thresh) {
				GameObject.Find("Sherer100").GetComponent<textureRenew>().divingStatus = DivingStatus.GoingDown;
			}
			break;
		case DivingStatus.FirstEndLoop:
			if(Input.acceleration.x > dive_trigger_up_thresh){
				GameObject.Find("Sherer100").GetComponent<textureRenew>().divingStatus = DivingStatus.GoingUp;
			}
			break;
		case DivingStatus.GoingDown:
		case DivingStatus.GoingUp:
		default:
			break;
		}
	}
}
