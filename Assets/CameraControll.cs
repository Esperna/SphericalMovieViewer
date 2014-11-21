using UnityEngine;
using System.Collections;

public class CameraControll : MonoBehaviour {

	void Update () {
		transform.Rotate(
			Vector3.right * 
			Time.deltaTime);
	}
}
