using UnityEngine;
using System.Collections;

public class CameraControll : MonoBehaviour {

	void Update () {
		transform.Rotate(
			new Vector3(0, 10, 0) * 
			Time.deltaTime);
	}
}
