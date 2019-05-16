using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSfxPrefab : MonoBehaviour
{
    [SerializeField] AudioClip[] m_clips;
    [SerializeField] GameObject m_prefab;

    public void CreatePrefab()
    {
        // ランダムな AudioClip を選ぶ
        int r = Random.Range(0, 100);
        r = r % m_clips.Length;
        AudioClip clip = m_clips[r];

        // プレハブを生成して AudioSource に AudioClip をセットする
        var go = Instantiate(m_prefab);
        AudioSource audioSource = go.GetComponent<AudioSource>();

        if (audioSource)
        {
            audioSource.clip = clip;
        }
    }
}
