using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    /// <summary>シーン上に存在する Star の数</summary>
    int m_starCount;

    void Start()
    {
        // 敵 (Star) の数を集計する
        StarController[] stars = GameObject.FindObjectsOfType<StarController>();
        m_starCount = stars.Length;

        // 課題 2. インスペクターから Star に設定した Events On Death を全て削除し、以下に「スクリプトから OnStarKilled() を m_eventsOnDeath に設定する処理」を記述せよ。
        foreach(var star in stars)
        {
            star.m_eventsOnDeath.AddListener(OnStarKilled);
        }
    }

    void Update()
    {

    }

    /// <summary>
    /// 敵 (Star) が消える時に呼び出される
    /// </summary>
    public void OnStarKilled()
    {
        m_starCount--;
        Debug.Log("Star: あと " + m_starCount + "個");
        if (m_starCount < 1)
        {
            Debug.Log("Clear!");
        }
    }
}
