using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 音を鳴らして消える。
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class PlaySfx : MonoBehaviour
{
    AudioSource m_audioSource;

    void Start()
    {
        m_audioSource = GetComponent<AudioSource>();
        m_audioSource.Play();
    }

    void Update()
    {
        // 再生中でなければ自分自身を破棄する。
        if (!m_audioSource.isPlaying)
        {
            Debug.Log("AudioSource is not playing. Destroy...");
            Destroy(gameObject);
        }
    }
}
