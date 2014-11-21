using UnityEngine;
using System.Collections;

public class TextureChange : MonoBehaviour {
	
	public Texture image;
	public Texture image2;
	public Texture image3;
	private int index = 0;
	
	// Use this for initialization
	void Start () {
		//gameObject取得
		renderer.material = renderer.materials[index];
	}
	
	// Update is called once per frame
	void Update () {
		//if (Input.GetMouseButtonDown(2))
		//{
		index++;
		if (index > 3 - 1) {
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
		
		//renderer.material = renderer.materials[index];
		//renderer.material.mainTexture = 
		
		Debug.Log (index);
	}
	//}
}
