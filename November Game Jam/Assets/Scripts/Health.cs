using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
	public int health = 100;
	public int maxHealth = 100;
	public bool dead = false;
	public bool hurt = false;
	public bool removeOnDeath = false;
	public AudioClip hurtSound;
	public GameObject deathSound;
	
	private AudioSource audioS;

	void Start()
	{
		audioS = GetComponent<AudioSource>();
	}

	public void damage(int amount)
	{
		hurt = true;
		health -= amount;
		if(audioS != null && hurtSound != null) audioS.PlayOneShot(hurtSound); //fix the audio stuff?
		
		if(health <= 0)
		{
			health = 0;
			dead = true;
			if(deathSound != null) Instantiate(deathSound);
			if(removeOnDeath) gameObject.SetActive(false);
		}
	}
	
	public void heal(int amount)
	{
		health += amount;
		if(health > maxHealth) health = maxHealth;
	}
	public void Update()
	{
		if(hurt)
			hurt = false;
	}
}	