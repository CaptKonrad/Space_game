using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float jetPackForce = 10;
	public GameObject bullet;
	public float bulletForce = 750;
	
	public Vector2 healthBarPosition;
	public Vector2 healthBarSize;
	
	private Transform Arm;
	private Rigidbody2D rb;
	private Health hp;
	private AudioSource jetPackSound;
	private AudioSource shootSound;
	
	// Use this for initialization
	void Start ()
	{
		Arm = transform.GetChild(0);
		rb = gameObject.GetComponent<Rigidbody2D>();
		hp = gameObject.GetComponent<Health>();
		jetPackSound = GetComponent<AudioSource>();
		shootSound = Arm.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 mp3 = Input.mousePosition;
		mp3 = Camera.main.ScreenToWorldPoint(mp3);
		
		Vector2 mp = new Vector2(mp3.x, mp3.y);
		
		//Fire gun
		if(Input.GetMouseButtonDown(0))
		{
			GameObject newBullet = Instantiate(bullet, Arm.transform.GetChild(0).transform.position, Arm.transform.GetChild(0).transform.rotation) as GameObject;
			newBullet.GetComponent<Rigidbody2D>().AddForce((mp-new Vector2(transform.position.x, transform.position.y)).normalized * bulletForce);
			shootSound.Play();
		}
		
		//rotate arm
		Arm.transform.eulerAngles = new Vector3(0, 0, (Mathf.Atan2(mp.y - Arm.transform.position.y, mp.x - Arm.transform.position.x)) * 180/Mathf.PI);
	
		//rotate self
		//transform.localScale = new Vector3((mp.x < transform.position.x)? -1 : 1, transform.localScale.y, transform.localScale.z);
	}
	
	void FixedUpdate()
	{
		if(Mathf.Abs(Input.GetAxis("Horizontal")) > 0.5f || Mathf.Abs (Input.GetAxis("Vertical")) > 0.5f)
		{
			if(!jetPackSound.isPlaying)
				jetPackSound.Play();
		}
		else
		{
			jetPackSound.Stop();
		}
		
		rb.AddForce(new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical")) * jetPackForce);
	}
}