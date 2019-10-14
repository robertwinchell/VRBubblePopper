using UnityEngine;
using System.Collections;

public class MoveButterfly : MonoBehaviour {

	public Vector3 displacement = new Vector3(5f,2f,5f);
	public float  desplVel = 1f;
	public Renderer myrender;

float iniRndX,iniRndY,iniRndZ;
	Vector3 pos0;


	// Use this for initialization
	void Start () {
		// UPDATED CODE:::::::::::::::::::::::::::::::::::::::::::::::::::::::::
		// CHANGED THIS too
		displacement = new Vector3 (
			Random.Range(displacement.x-2.7f,displacement.x+4.7f),
			Random.Range(displacement.y,displacement.y+3.7f),
			Random.Range(displacement.z-1.7f,displacement.z+5.7f)
			
			);



		iniRndX = Random.Range(Random.Range(0f,200f), 500f);
		iniRndY = Random.Range(Random.Range(0f,200f), 500f);
		iniRndZ = Random.Range(Random.Range(0f,200f), 500f);
		
		desplVel *= Random.Range(0.5f, 2f);
		
		pos0 = transform.localPosition;
		transform.localEulerAngles = 
			new Vector3 (transform.localEulerAngles.x,
			             Random.Range(1f,360f),
			             transform.localEulerAngles.z);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void FixedUpdate () {
		UpdateDespl();
	}
	
	void UpdateDespl() {


		float x= (float)(Mathf.PerlinNoise(Time.time*desplVel +iniRndX, iniRndX) -0.3f) *displacement.x*Random.Range(Random.Range(0.5f,2.5f),Random.Range(7.9f,15.5f));
		float y= (float)(Mathf.PerlinNoise(iniRndY, iniRndY+ Time.time*desplVel) -0.3f) *displacement.y*Random.Range(1.5f,Random.Range(1.5f,7.5f));
		float z= (float)(Mathf.PerlinNoise(iniRndZ, iniRndZ+ Time.time*desplVel) +0.5f) *displacement.z*Random.Range(Random.Range(1.5f,3.5f),Random.Range(5.9f,22.5f));
		
		
		Vector3 despl = new Vector3(x,y,z);
		Quaternion rot = Quaternion.LookRotation(despl, Vector3.up);
		Quaternion rot2;

		rot2 = new Quaternion ( 270f,
		 0f,
		  rot.eulerAngles.z + 90f, 
		   rot.w);
		rot = rot2;

		
		GetComponent<Rigidbody>().AddForce(despl, ForceMode.Force);
		transform.rotation = Quaternion.Lerp(transform.rotation, rot, 1f);
		
		if ((transform.localPosition-pos0).sqrMagnitude>displacement.sqrMagnitude) {
			GetComponent<Rigidbody>().AddForce((pos0 -transform.localPosition)*Random.Range(1.5f,3.5f), ForceMode.Force);
		}	
	}
}
