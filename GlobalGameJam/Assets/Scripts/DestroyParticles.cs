using UnityEngine;
using System.Collections;

public class DestroyParticles : MonoBehaviour 
{
	void Awake () 
	{
		Destroy(this.gameObject, this.GetComponent<ParticleSystem>().duration);
	}
}