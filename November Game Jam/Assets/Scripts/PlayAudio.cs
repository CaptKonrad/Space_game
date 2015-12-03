using UnityEngine;
using System.Collections;

public class PlayAudio : MonoBehaviour
{
	private AudioSource audioS;
	// Use this for initialization
	void Start()
	{
		audioS = GetComponent<AudioSource>();
		audioS.playOnAwake = true;
	}
	
	// Update is called once per frame
	void Update()
	{
		if(!audioS.isPlaying)
		{
			gameObject.SetActive(false);
		}
	}
}
