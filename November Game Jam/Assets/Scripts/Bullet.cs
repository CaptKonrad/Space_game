using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
	public int Damage = 10;
	public bool friendly = true;
	//public GameObject alienDeathSound;
	public GameObject bulletSound;
	
	// Use this for initialization
	void Start ()
	{
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			if(!friendly)
			{
				other.GetComponent<Health>().damage(Damage);
				gameObject.SetActive(false);
			}
		}
		else if(other.tag == "Enemy")
		{
			if(friendly)
			{
				other.GetComponent<Health>().damage(Damage);
				other.GetComponent<Rigidbody2D>().AddForceAtPosition(GetComponent<Rigidbody2D>().velocity.normalized * 150, transform.position);
				gameObject.SetActive(false);
			}
		}
		
		else if(other.tag == "Bullet")
		{
			Instantiate(bulletSound);
			gameObject.SetActive(false);
		}
		
		else
		{
			gameObject.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update()
	{
		
	}
}
