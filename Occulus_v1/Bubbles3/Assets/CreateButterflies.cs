using UnityEngine;using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CreateButterflies : MonoBehaviour {

	public bool create;

	public int ButNumber;

	public GameObject butters;
	public InputField num;

	public List<GameObject> allbuts=new List<GameObject>();
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	public  void UpdateButterflies () {

		ButNumber = int.Parse (num.text);

		if (allbuts.Count > 0) 
		{

			for (int b=allbuts.Count-1;b >= 0; --b)
			{



				Destroy(allbuts[b].gameObject);
			}
			 allbuts.Clear();

		}



		for (int a=0; a<ButNumber;a++)
		{
			GameObject newe=Instantiate(butters, transform.position, Quaternion.identity) as GameObject;
			allbuts.Add(newe);


			// CHANGED CODE:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
			/*
			newe.GetComponent<MoveButterfly>().displacement=new
				Vector3 (Random.Range(1f,3f),
				         Random.Range(1f,3f),
				         Random.Range(1f,3f)

				         );*/





			newe.GetComponent<MoveButterfly>().myrender.material.color=new Color (
				Random.Range(0.5f,1f),
				Random.Range(0.5f,1f),
				Random.Range(0.5f,1f)
				);
				
				
		}
		

	
	}
}
