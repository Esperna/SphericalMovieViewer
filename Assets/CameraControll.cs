using UnityEngine;
using System.Collections;

public class CameraControll : MonoBehaviour {

	void Update () {

		if (Input.GetKeyDown(KeyCode.A)) {
			GameObject.Find("Sherer100").GetComponent<textureRenew>().divingStatus = DivingStatus.GoingDown;
		} else if (Input.GetKeyDown(KeyCode.B)) {
			GameObject.Find("Sherer100").GetComponent<textureRenew>().divingStatus = DivingStatus.GoingUp;
		}
		transform.Rotate(
			new Vector3(0, 10, 0) * 
			Time.deltaTime);
	}
}
