using UnityEngine;
using System.Collections;

public class HealthBarScript : MonoBehaviour
{
	public Health hp;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update()
	{
		float normalizedhealth = (float)hp.health/hp.maxHealth;
		transform.localScale = new Vector3(normalizedhealth, transform.localScale.y, transform.localScale.z);
		transform.localPosition = new Vector3(hp.health/2 - hp.maxHealth/2, transform.localPosition.y, transform.localPosition.z);
	}
}
