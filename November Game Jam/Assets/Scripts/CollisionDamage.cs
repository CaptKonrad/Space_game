using UnityEngine;
using System.Collections;

public class CollisionDamage : MonoBehaviour
{
	public float VelocityThreshold = 30;
	public float DamageMultiplier = 1;
	
	private Rigidbody2D thisrb;
	private Health hp;

	// Use this for initialization
	void Start ()
	{
		thisrb = gameObject.GetComponent<Rigidbody2D>();
		hp = gameObject.GetComponent<Health>();
	}
	
	void OnCollisionEnter2D(Collision2D other)
	{
 		if(other.gameObject.tag != "Bullet")
		{
			float dam = ((other.relativeVelocity.magnitude - VelocityThreshold) - thisrb.velocity.magnitude) * DamageMultiplier;				
			if(dam > 0)
			{
				if(hp != null)
				{
					hp.damage ((int)dam);
				}
				else
				{
					gameObject.SetActive(false);
				}
			}
		}
	}
}
