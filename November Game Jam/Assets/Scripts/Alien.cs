using UnityEngine;
using System.Collections;

public class Alien : MonoBehaviour
{
	public GameObject bullet;
	public float engageDistance = 100;
	
	private GameObject player;
	private Rigidbody2D rb;
	private int timeToFire = 0;
	private AudioSource shootSound;
	
	// Use this for initialization
	void Start ()
	{
		player = GameObject.FindGameObjectsWithTag("Player")[0]; ///I dont know if this is bad to do...
		rb = gameObject.GetComponent<Rigidbody2D>();
		shootSound = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void FixedUpdate()
	{
		if(Vector2.Distance(transform.position, player.transform.position) < engageDistance && player.activeSelf)
		{
			if(timeToFire <= 0)
			{
				GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.Euler(0,0,Mathf.Atan2(player.transform.position.y - transform.position.y, player.transform.position.x - transform.position.x) * 180/Mathf.PI)) as GameObject;
				newBullet.GetComponent<Rigidbody2D>().AddForce((new Vector3(player.transform.position.x, player.transform.position.y, 0)-new Vector3(transform.position.x, transform.position.y, 0)).normalized * 1500);
				timeToFire = 45;
				shootSound.Play();
			}
			timeToFire--;
		}
	}
}
