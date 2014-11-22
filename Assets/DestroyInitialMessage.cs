using UnityEngine;
using System.Collections;

public class DestroyInitialMessage : MonoBehaviour {

	private GameObject gui_text;

	// Use this for initialization
	void Start () {
		const int destroy_time = 3;
		gui_text = GameObject.Find("InitialText");
		Destroy (gui_text, destroy_time);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
