using UnityEngine;
using System.Collections;

public class TextureChange : MonoBehaviour {
	
	public Texture image;
	public Texture image2;
	public Texture image3;
	private int index = 0;
	private float oldTime;
	private const float INTERVAL = 0.1f;
	private int frame = 0;
	private float frameRate = 0f;

	// Use this for initialization
	void Start () {
		renderer.material = renderer.materials[index];
		oldTime = Time.realtimeSinceStartup;
	}
	
	// Update is called once per frame
	void Update () {
		frame++;
		float time = Time.realtimeSinceStartup - oldTime;
		if (time >= INTERVAL)
		{
			frameRate = frame / time;
			Debug.Log("frame rate:" + frameRate);
			index++;
			if (index > 2) {
				index = 0;
			}
			switch (index) {
			case 0:
				renderer.material.mainTexture = image;
				break;
			case 1:
				renderer.material.mainTexture = image2;
				break;
			case 2:
				renderer.material.mainTexture = image3;
				break;
			}
			oldTime = Time.realtimeSinceStartup;
			frame = 0;
		}
	}
}
