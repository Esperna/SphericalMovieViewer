using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class textureRenew : MonoBehaviour {
	
	private List<Texture> texList;
	private int frame;
	
	private float oldTime;
	private const float INTERVAL = 0.1f;

	private int initialLoopFrame = 10;
	
	void Start (){
		texList = new List<Texture> ();
		for (int i = 0; i <= 100; i++) {
			texList.Add (Resources.Load ("frame" + i.ToString ()) as Texture);
		}
		
		oldTime = Time.realtimeSinceStartup;
		frame = 0;
	}
	
	void Update () {
		
		float time = Time.realtimeSinceStartup - oldTime;
		if (time >= INTERVAL)
		{
			bool isDivingNow = GameObject.Find("Main Camera").GetComponent<GyroCameraController>().is_diving_now;
			Debug.Log(isDivingNow);
			renderer.material.mainTexture = texList [frame];
			
			frame++;
			if (frame >= texList.Count || (frame >= initialLoopFrame && !isDivingNow)) {
				frame = 0;
			}
			oldTime = Time.realtimeSinceStartup;
		}
	}
}
