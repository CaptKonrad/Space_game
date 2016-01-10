using UnityEngine;
using System.Collections;

public class BasicGun : Item
{
	public Rigidbody2D projectile;
	public float projectileForce = 1500f;
	public int projectilesPerShot = 1;
	public float fireRate = 500;
	public bool automatic = false;
	public float accuracySpread = 0;
	
	private float timer = 0f;
	private bool firing = false;

	//The Weapon Must be instantiated to be used in this manner
	void Update()
	{
		//Debug.Log(firing);
		if(timer <= 0 && this.firing)
		{
			for(int i = 0; i < projectilesPerShot; i++)
			{
				float angle = transform.rotation.eulerAngles.z + Random.Range(-accuracySpread/2f, accuracySpread/2f);
				angle = angle * Mathf.PI/180;
				//Debug.Log(angle);
				Rigidbody2D p = (Rigidbody2D)Instantiate(projectile, transform.position, transform.rotation);
				Vector2 force = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
				p.AddForce(force * projectileForce);
			}
			if(!automatic) this.firing = false;
			timer = 1/fireRate;
		}
		
		if(timer > 0) timer -= Time.deltaTime;
	}
	
	override
	public void Use()
	{
		if(timer <= 0) firing = true;
	}
	
	override
	public void Release()
	{
		 firing = false;
	}
}
