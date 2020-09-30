using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

	public static AudioManager instance;

	public AudioMixerGroup mixerGroup;

	public Sound[] sounds;

	void Awake()
	{
		if (instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}

		foreach (Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.loop = s.loop;

			s.source.outputAudioMixerGroup = mixerGroup;
		}
	}

	public void Play(string sound)
	{
		Sound s = Array.Find(sounds, item => item.name == sound);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}

		float multiplier = GameManager.instance.masterVolume;
		if (s.music) multiplier *= GameManager.instance.musicVolume;
		else multiplier *= GameManager.instance.sfxVolume;

		s.source.volume = s.volume * multiplier;
		s.source.pitch = s.pitch;

		s.source.Play();
	}

	public void Play(string sound, bool playIfAlreadyPlaying)
	{
		Sound s = Array.Find(sounds, item => item.name == sound);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}

		if (!playIfAlreadyPlaying && s.source.isPlaying) return;

		float multiplier = GameManager.instance.masterVolume;
		if (s.music) multiplier *= GameManager.instance.musicVolume;
		else multiplier *= GameManager.instance.sfxVolume;

		s.source.volume = s.volume * multiplier;
		s.source.pitch = s.pitch;

		s.source.Play();
	}

	public void Stop(string sound)
	{
		Sound s = Array.Find(sounds, item => item.name == sound);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}

		if (!s.source.isPlaying)
		{
			return;
		}

		s.source.Stop();
	}

	public void Stop(string sound, bool announce)
	{
		Sound s = Array.Find(sounds, item => item.name == sound);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}

		if (!s.source.isPlaying && announce == true)
		{
			Debug.LogWarning("Sound: " + name + " not playing!");
			return;
		}

		s.source.Stop();
	}

	private void Update()
	{
		for (int i = 0; i < sounds.Length; i ++)
		{
			Sound s = Array.Find(sounds, item => item.name == sounds[i].name);
			float multiplier = GameManager.instance.masterVolume;
			if (s.music) multiplier *= GameManager.instance.musicVolume;
			else multiplier *= GameManager.instance.sfxVolume;
			s.source.volume = s.volume * multiplier;
		}
	}

}
