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
	private Inventory inventory;
	private Item currentItem;
	private int currentItemNum;
	private AudioSource jetPackSound;
	private AudioSource shootSound;
	
	//Test
	//public Item weapon;
	//public Item w;
	
	// Use this for initialization
	void Start ()
	{
		Arm = transform.GetChild(0);
		rb = gameObject.GetComponent<Rigidbody2D>();
		hp = gameObject.GetComponent<Health>();
		inventory = GetComponent<Inventory>();
		jetPackSound = GetComponent<AudioSource>();
		shootSound = Arm.GetComponent<AudioSource>();
		
		//w = Instantiate(weapon);
		//w.transform.SetParent(Arm.GetChild(0).transform, false);//this maybe too well done.. or just broken
		Equip(0);
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 mp3 = Input.mousePosition;
		mp3 = Camera.main.ScreenToWorldPoint(mp3);
		Vector2 mp = new Vector2(mp3.x, mp3.y);
		
		//use Currently selected Item
		if(Input.GetMouseButtonDown(0)) currentItem.Use();
		if(Input.GetMouseButtonUp(0)) currentItem.Release();
		
		//Select weapons
		if(Input.GetKeyDown("q"))//FIX THIS SHIT!!!
		{
			Equip(((++currentItemNum)%inventory.Size()));
		}	
		
		//rotate arm
		Arm.transform.eulerAngles = new Vector3(0, 0, (Mathf.Atan2(mp.y - Arm.transform.position.y, mp.x - Arm.transform.position.x)) * 180/Mathf.PI);
		
		/*
		//rotate self
		if((mp.x < transform.position.x && facingRight) || (mp.x > transform.position.x && !facingRight))
		{
			transform.eulerAngles = new Vector3(transform.localRotation.x, transform.localRotation.y + 180, transform.localRotation.z);
			Arm.transform.position = new Vector3(Arm.transform.position.x, Arm.transform.position.y, -Arm.transform.position.z);// this is sloppy
			facingRight = !facingRight;
		}
		*/
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
	
	private void Equip(int it)
	{
		if(inventory.Get(it) != null)
		{
			if(currentItem != null) Destroy(currentItem.gameObject);
			currentItem = Instantiate(inventory.Get(it));
			currentItem.transform.SetParent(Arm.GetChild(0).transform, false);
		}
	}
}