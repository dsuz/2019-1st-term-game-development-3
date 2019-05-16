using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// カウントダウン→スタート演出の処理をする。適当な GameObject にアタッチして使う。
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class CountdownController : MonoBehaviour
{
    /// <summary>タイマー</summary>
    float m_timer = 0f;
    AudioSource m_audioSource;
    /// <summary>いくつカウントダウンするか</summary>
    [SerializeField] int m_count = 3;
    /// <summary>カウントダウンする間隔</summary>
    [SerializeField] float m_countdownInterval = 1f;
    /// <summary>カウントを表示する Text</summary>
    [SerializeField] Text m_counterText;
    /// <summary>カウントダウン時に鳴らす SE</summary>
    [SerializeField] AudioClip m_countdownClip;
    /// <summary>カウントダウン終了時に鳴らす SE</summary>
    [SerializeField] AudioClip m_startClip;

    void Start()
    {
        m_audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (m_count < 0) return;    // カウントダウンが終わっていたら何もしない

        m_timer += Time.deltaTime;  // タイマーで時間を測る

        if (m_timer > m_countdownInterval)  // カウントダウンする時間が経過したら
        {
            m_timer = 0;    // タイマーをリセットして
            Count(m_count); // カウント処理をして
            m_count -= 1;   // カウントダウンする
        }
    }

    /// <summary>
    /// カウント処理（表示の更新と SFX の再生）をする。
    /// </summary>
    /// <param name="count"></param>
    void Count(int count)
    {
        Debug.Log("Count: " + m_count);

        // カウントを表示する
        if (m_counterText)
        {
            m_counterText.text = m_count.ToString();
        }

        // 以下で SFX を鳴らす
        if (count > 0)
        {
            m_audioSource.PlayOneShot(m_countdownClip);
        }
        else
        {
            m_audioSource.PlayOneShot(m_startClip);
        }
    }

}
