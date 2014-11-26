using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class textureRenew : MonoBehaviour {

	public DivingStatus divingStatus;

	private List<Texture> texList;
	private int frame;
	
	private float oldTime;
	private const float INTERVAL = 0.1f;

	//private int initialLoopFrame = 1;
	//private int endLoopFrame = 1;
	private const int number_of_underwater_frame = 225;
	private const int underwater_start_frame = 0;
	private const int underwater_end_frame = underwater_start_frame + number_of_underwater_frame - 1;

	void Start (){
		divingStatus = DivingStatus.FirstLoop;
		texList = new List<Texture> ();
		for (int i = 1; i <= number_of_underwater_frame; i++) {
			texList.Add (Resources.Load ("underwater_frame" + i.ToString ()) as Texture);
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
		case DivingStatus.FirstLoop:
			frame = underwater_start_frame;
			break;
		case DivingStatus.FirstEndLoop:
			frame = underwater_end_frame;
			break;
		case DivingStatus.GoingDown:
			frame++;
			if (frame >= underwater_end_frame) {
				divingStatus = DivingStatus.FirstEndLoop;
			}
			break;
		case DivingStatus.GoingUp:
			frame--;
			if (frame <= underwater_start_frame) {
				divingStatus = DivingStatus.FirstLoop;
			}
			break;
		default:
			break;
		}

	}
}
