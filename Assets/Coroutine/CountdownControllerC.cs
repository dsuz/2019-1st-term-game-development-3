using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// カウントダウン→スタート演出の処理をする。適当な GameObject にアタッチして使う。
/// </summary>
[RequireComponent(typeof(AudioSource))]

public class CountdownControllerC : MonoBehaviour
{
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
        StartCoroutine(Countdown(m_count));     // コルーチンを呼び出す
    }

    void Update()
    {

    }

    /// <summary>
    /// カウントダウン処理をする
    /// </summary>
    /// <param name="count">カウントする数</param>
    /// <returns></returns>
    IEnumerator Countdown(int count)
    {
        for (int i = count; i > -1; i--)
        {
            yield return new WaitForSeconds(m_countdownInterval);   // 待つ

            Debug.Log("Count: " + i.ToString());

            // 表示を更新する
            if (m_counterText)
            {
                m_counterText.text = i.ToString();
            }

            // SFX を鳴らす
            if (i > 0)
            {
                m_audioSource.PlayOneShot(m_countdownClip);
            }
            else
            {
                m_audioSource.PlayOneShot(m_startClip);
            }
        }
    }
}
