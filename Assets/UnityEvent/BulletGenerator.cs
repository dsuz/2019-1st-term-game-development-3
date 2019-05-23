﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Bullet を生成する。生成した時、WallController にイベントを登録する
/// </summary>
public class BulletGenerator : MonoBehaviour
{
    [SerializeField] GameObject m_bulletPrefab;
    
    /// <summary>
    /// プレハブを生成する
    /// </summary>
    public void GenerateBullet()
    {
        var go = Instantiate(m_bulletPrefab);
        go.transform.position = new Vector3(Random.Range(-3f, 3f), 0f, 0f);

        // イベントを登録する
        GameObject.FindObjectOfType<WallController>().m_onCrash.AddListener(go.GetComponent<BulletController>().Fire);
    }
}
