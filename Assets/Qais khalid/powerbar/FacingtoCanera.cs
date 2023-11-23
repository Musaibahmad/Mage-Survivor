using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacingtoCanera : MonoBehaviour {

	//[Range(0.0f, 1.0f)]
	public float power=1;


	public float TotalPoint=200;
	public float hitpoint=200;
	public TextMesh TextPower;
	public GameObject WhiteBar;
	// Use this for initialization
	void Start () {
		power = (hitpoint / TotalPoint);
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale= new Vector3(1,1,power);
		transform.rotation = Quaternion.LookRotation(-Camera.main.transform.right, -Camera.main.transform.forward);
		WhiteBar.transform.rotation = Quaternion.LookRotation(-Camera.main.transform.right, -Camera.main.transform.forward);
		TextPower.transform.rotation=Quaternion.LookRotation(Camera.main.transform.forward,Camera.main.transform.up);
	}

	public void powerbarset(float f_hitpoint)
	{
		//Debug.LogError("f_hitpoint "+ f_hitpoint);
		hitpoint = f_hitpoint;
		TextPower.text = hitpoint + "/" + TotalPoint;
		power = (float)(hitpoint / TotalPoint);
		if (hitpoint == 0)
        {
			TextPower.text = "";
			power = 0.0f;
			WhiteBar.SetActive(false);
			this.gameObject.SetActive(false);

		}
	}
}
