using System.Collections.Generic;
using UnityEngine;

public static class SoundManager
{
    public enum Sound {
        PlayerMove,
        PlayerHit,
        PlayerAttack,
        EnemyHit,
        EnemyDie,
    }

    private static Dictionary<Sound, float> soundTimerDictionary = new Dictionary<Sound, float>();

    public static void PlaySound(Sound sound, Vector3 position) {
        if (CanPlaySound(sound)) {
            GameObject soundGo = new GameObject("Sound");
            soundGo.transform.position = position;
            AudioSource audioSource = soundGo.AddComponent<AudioSource>();
            audioSource.clip = GameManager.Instance.soundAudioClipMap[sound];
            audioSource.maxDistance = 100f;
            audioSource.spatialBlend = 1f;
            audioSource.rolloffMode = AudioRolloffMode.Linear;
            audioSource.Play();
            soundTimerDictionary[sound] = Time.time;

            Object.Destroy(soundGo, audioSource.clip.length);
        }
    }

    public static void PlaySound(Sound sound) {
        if (CanPlaySound(sound)) {
            GameObject soundGo = new GameObject("Sound");
            AudioSource audioSource = soundGo.AddComponent<AudioSource>();
            audioSource.clip = GameManager.Instance.soundAudioClipMap[sound];
            audioSource.Play();
            soundTimerDictionary[sound] = Time.time;
        }
    }

    private static bool CanPlaySound(Sound sound) {
        if (GameManager.Instance.soundAudioClipMap[sound] == null) {
            Debug.LogWarning($"Sound {sound} not implemented");
            return false;
        }

        switch (sound) {
            default: 
                return true;
            case Sound.PlayerMove:
                if (soundTimerDictionary.ContainsKey(sound)) {
                    float lastTimePlayed = soundTimerDictionary[sound];
                    float playerMoveTimerMax = .05f; // sound cooldown
                    return (lastTimePlayed + playerMoveTimerMax < Time.time);
                }
                break;
        }

        return true;
    }
}
