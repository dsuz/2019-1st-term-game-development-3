using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 音を鳴らして消える。
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class PlaySfxInvoke : MonoBehaviour
{
    AudioSource m_audioSource;

    void Start()
    {
        m_audioSource = GetComponent<AudioSource>();
        m_audioSource.Play();
        Invoke("DestroyMyself", m_audioSource.clip.length); // 本来は Destroy(gameObject, m_audioSource.clip.length) でよいのだが、あえて Invoke を使う
    }

    void DestroyMyself()
    {
        Debug.Log("Destroy myself.");
        Destroy(gameObject);
    }
}
