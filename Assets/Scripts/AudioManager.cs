using UnityEngine;

public static class AudioManager {

    public static void PlaySound
    (
        Sounds sound, 
        float  volume = 1f,
        float  pitch  = 1f,
        bool   loop   = false
    ) {

        AudioClip audioClip = Resources.Load<AudioClip>($"Audio/{sound}");
        if (audioClip == null) {
            Debug.LogError($"Audio clip not found: {sound}");
            return;
        }

        GameObject  gameObject  = new GameObject(sound.ToString());
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip   = audioClip;
        audioSource.volume = volume;
        audioSource.pitch  = pitch;
        audioSource.loop   = loop;
        audioSource.Play();

        if (!loop) {
            Object.Destroy(gameObject, audioClip.length);
        }
    }

}
