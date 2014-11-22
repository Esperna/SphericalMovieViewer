using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class textureRenew : MonoBehaviour {

	public DivingStatus divingStatus;

	private List<Texture> texList;
	private int frame;
	
	private float oldTime;
	private const float INTERVAL = 0.1f;

	private int initialLoopFrame = 1;
	private int endLoopFrame = 1;
	
	void Start (){
		divingStatus = DivingStatus.InitialLoop;
		texList = new List<Texture> ();
		for (int i = 1; i <= 77; i++) {
			texList.Add (Resources.Load ("frame" + i.ToString ()) as Texture);
		}
		
		oldTime = Time.realtimeSinceStartup;
		frame = 0;
	}
	
	void Update () {
		float time = Time.realtimeSinceStartup - oldTime;
		if (time >= INTERVAL)
		{
			renewTexture();
			oldTime = Time.realtimeSinceStartup;
		}
	}

	void renewTexture() {
		renderer.material.mainTexture = texList [frame];

		Debug.Log(divingStatus.ToString());

		switch (divingStatus) {
		case DivingStatus.InitialLoop:
			frame++;
			if (frame >= initialLoopFrame) {
				frame = 0;
			}
			break;
		case DivingStatus.GoingDown:
			frame++;
			if (frame >= texList.Count - 1) {
				divingStatus = DivingStatus.EndLoop;
			}
			break;
		case DivingStatus.EndLoop:
			frame--;
			if (frame <= texList.Count - 1 - endLoopFrame) {
				frame = texList.Count - 1;
			}
			break;
		case DivingStatus.GoingUp:
			frame--;
			if (frame <= 0) {
				divingStatus = DivingStatus.InitialLoop;
			}
			break;
		default:
			break;
		}
		//bool isDivingNow = GameObject.Find("Main Camera").GetComponent<GyroCameraController>().is_diving_now;
		//Debug.Log(isDivingNow);
		//renderer.material.mainTexture = texList [frame];
		
		//frame++;
		//if (frame >= initialLoopFrame && !isDivingNow) {
		//	frame = 0;
		//} else if (frame >= texList.Count) {
		//	
		//}
	}
}
