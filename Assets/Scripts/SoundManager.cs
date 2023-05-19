using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
	
	[SerializeField] private GameObject sfx;

	//those are public to make it possible to choose the specific AudioClip from outside the class
	[Header("Audio clips")]
	public AudioClip music;
	public AudioClip targetHit;
	public AudioClip playerHit;
	public AudioClip bonusCollected;
	public AudioClip buttonSound;

	public void PlaySfx(AudioClip _audioClip)
	{
		createAndPlaySound(_audioClip, false);
	}
	public void PlayMusic()
	{
		createAndPlaySound(music, true);
	}
	private void createAndPlaySound(AudioClip clip,bool _loop)
	{
		GameObject sfxGo = Instantiate(sfx, Vector3.zero, Quaternion.Euler(Vector3.zero), transform);
		AudioSource _audios = sfxGo.GetComponent<AudioSource>();
		_audios.clip = clip;
		_audios.Play();
		_audios.loop = _loop;
		if(!_loop)
			Destroy(sfxGo, clip.length);
	}

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Destroy(this);
			return;
		}
		Instance = this;
	}

		
	
}
