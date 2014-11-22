using UnityEngine;
using System.Collections;

public class GyroCameraController : MonoBehaviour {

	void Update () 
	{
		Quaternion gyro = Input.gyro.attitude;
		this.transform.localRotation = Quaternion.Euler (90, 0, 0) * (new Quaternion (-gyro.x, -gyro.y, gyro.z, gyro.w));
		
		Debug.Log (Input.acceleration.x);

		switch (GameObject.Find ("Sherer100").GetComponent<textureRenew> ().divingStatus) {
		case DivingStatus.InitialLoop:
			if (Input.GetKeyDown(KeyCode.S)) {
				GameObject.Find("Sherer100").GetComponent<textureRenew>().divingStatus = DivingStatus.GoingDown;
			}
			break;
		case DivingStatus.EndLoop:
			if(Input.GetKeyDown(KeyCode.W)){
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
