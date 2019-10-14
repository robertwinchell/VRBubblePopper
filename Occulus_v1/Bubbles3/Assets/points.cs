using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class points : MonoBehaviour {
	public AudioClip popsound;
	public  int point;
	public Text scoreText;
	public InputField ParticleInput;
	public int particles;

		void OnParticleCollision(GameObject other) {
			
		point++;

		scoreText.text = "" + point.ToString ();
		GetComponent<AudioSource> ().PlayOneShot (popsound);



			}

	void LateUpdate()
	{
		GetComponent<ParticleSystem> ().maxParticles = particles;
	}



	public void SetParticleNumbers()
	{
		particles = int.Parse (ParticleInput.text);

	}

		}


